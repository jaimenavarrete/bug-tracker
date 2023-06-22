using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Extensions
{
    public static class Middleware
    {
        public static WebApplication AddMiddlewarePipelines(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseCors("MainCORS");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks("/health/ready", new HealthCheckOptions
            {
                Predicate = (check) => check.Tags.Contains("ready"),
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(new
                    {
                        Status = report.Status.ToString(),
                        Checks = report.Entries.Select(entry => new
                        {
                            Name = entry.Key,
                            Status = entry.Value.Status.ToString(),
                            Exception = entry.Value.Exception?.Message ?? "None",
                            Duration = entry.Value.Duration.ToString(),
                        })
                    });

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });

            app.MapHealthChecks("/health/live", new HealthCheckOptions
            {
                Predicate = (_) => false
            });

            app.Run();

            return app;
        }
    }
}