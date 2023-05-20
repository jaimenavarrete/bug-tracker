using Microsoft.AspNetCore.Builder;

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

            app.Run();

            return app;
        }
    }
}