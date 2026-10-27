using Application.Services.SystemServices;
using Application.Services.UsersServices;
using APIS.Jobs;
using Core.DomainModels;
using Core.Dtos.JWT;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.IServices.UsersIServices;
using Core.Interfaces.Specifications;
using Core.Settings;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.Data;
using Infrastructure.Data.UnitOfWork;
using Infrastructure.Helpers;
using Infrastructure.Jobs;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;

namespace AshalLms.APIS.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddFrameworkServices(services);
            ConfigureLogging(services, configuration);
            RegisterApplicationServices(services);
            ConfigureDatabase(services, configuration);
            ConfigureEmailSettings(services, configuration);
            ConfigureJwtSettings(services, configuration);
            ConfigureCors(services);
            ConfigureOpenApi(services);
            ConfigureHangfire(services, configuration);
            return services;
        }

        private static void AddFrameworkServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSignalR();
        }

        private static void ConfigureLogging(IServiceCollection services, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .Enrich.With<SolvedLogEnricher>()
                .WriteTo.MSSqlServer(
                    connectionString: configuration.GetConnectionString("Default"),
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "LogModel",
                        AutoCreateSqlTable = false,
                        SchemaName = "dbo"
                    },
                    columnOptions: GetColumnOptions())
                .CreateLogger();
            Log.Logger = logger;
            services.AddSingleton<Serilog.ILogger>(logger);
            services.AddScoped<ILoggerService, LoggerService>();
        }
      
        private static void RegisterApplicationServices(IServiceCollection services)
        {
            // Core Services
            services.AddScoped<ClaimService>();
            services.AddHttpClient();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // File Service with special configuration
            services.AddScoped<IFileService>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<FileService>>();
                var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                return new FileService(logger, webRootPath);
            });

            // Infrastructure Services
            services.AddScoped<IEmailService, EmailService>();
            
            // Application Services (Business Logic)
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ChatMessagesCleanupJob>();
            services.AddScoped<NotificationsCleanupJob>();

            // Utilities
            services.AddSingleton<SolvedLogEnricher>();
            //services.AddScoped<DataSeeder>();
            services.AddScoped<FirebaseService>();
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        private static void ConfigureEmailSettings(IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailSettings>()
                ?? throw new InvalidOperationException("EmailConfiguration section is required.");
            services.AddSingleton(emailConfig);
        }

        private static void ConfigureJwtSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(
                                "https://localhost:7237",
                                "http://localhost:7237",
                                "https://localhost:7184",
                                "http://localhost:7184",
                                "http://127.0.0.1:5500",
                                "http://localhost:5500")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
        }

        private static void ConfigureOpenApi(IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "Captiny API",
                        Version = "v1",
                        Description = "ASP.NET Core Web API"
                    };

                    document.Components ??= new OpenApiComponents();

                    // SecuritySchemes uses IDictionary<string, IOpenApiSecurityScheme>
                    document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

                    // Add Bearer JWT security scheme
                    document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",                    // lowercase is the standard
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
                    };

                    // Global security requirement using OpenApiSecuritySchemeReference (.NET 10 style)
                    document.Security ??= new List<OpenApiSecurityRequirement>();

                    var schemeRef = new OpenApiSecuritySchemeReference("Bearer", document);

                    var requirement = new OpenApiSecurityRequirement
                    {
                        [schemeRef] = new List<string>()  // Empty list for scopes (JWT doesn't use scopes)
                    };

                    document.Security.Add(requirement);

                    return Task.CompletedTask;
                });
            });
        }

        private static void ConfigureHangfire(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddHangfire(config =>
                config.UseSimpleAssemblyNameTypeSerializer()
                      .UseRecommendedSerializerSettings()
                      .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                      {
                          CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                          SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                          QueuePollInterval = TimeSpan.Zero,
                          UseRecommendedIsolationLevel = true,
                          DisableGlobalLocks = true
                      }));

            services.AddHangfireServer();
        }

        private static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();
            // Remove all default columns
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.LogEvent);

            // Configure required columns
            columnOptions.Id.ColumnName = "Id";
            columnOptions.Id.DataType = SqlDbType.Int;
            columnOptions.Message.ColumnName = "Message";
            columnOptions.Message.DataLength = -1; // MAX length
            columnOptions.Level.ColumnName = "Level";
            columnOptions.Level.DataLength = 50;
            columnOptions.TimeStamp.ColumnName = "TimeStamp";
            columnOptions.Exception.ColumnName = "Exception";
            columnOptions.Exception.DataLength = -1;

            columnOptions.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn("Solved", SqlDbType.Bit)
            };

            return columnOptions;
        }
    }
}