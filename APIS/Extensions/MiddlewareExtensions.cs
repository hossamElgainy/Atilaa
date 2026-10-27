

using Captiny.APIS.Middlewares;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Captiny.APIS.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication UseCustomMiddleware(this WebApplication app)
        {
            app.UseStaticFiles();
            
            app.UseCors("CorsPolicy");
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            // Swagger JSON + UI with multiple documents (definitions) to pick from
            // Map OpenAPI endpoints
            app.MapOpenApi();
            // Also expose at classic Swagger path for compatibility
            app.MapOpenApi("/swagger/v1/swagger.json");

            // Configure Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "Captiny APIS v1");
                // Also provide classic endpoint for compatibility
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Captiny APIS v1 (Classic)");
                c.RoutePrefix = "swagger"; // This sets the Swagger UI at /swagger
                c.DocumentTitle = "Captiny API Documentation";
            });


            app.MapControllers();
            return app;
        }
    }
}
