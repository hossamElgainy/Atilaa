
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Captiny.APIS.Extensions
{
    public static class JwtAuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (string.IsNullOrWhiteSpace(secretKey))
                throw new InvalidOperationException("JWT:SecretKey configuration is required.");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretKey)),
                        ClockSkew = TimeSpan.Zero,
                        RoleClaimType = "Role" // Map the "Role" claim to the role claim type
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // SignalR in browsers sends token as query string (?access_token=...)
                            // for WebSockets / SSE requests instead of Authorization header.
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/chatHub"))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Authentication failed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization();

            return services;
        }
    }
}
