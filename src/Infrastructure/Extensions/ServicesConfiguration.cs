using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, string connectionString)
        {
            // Database
            services.AddDbContext<BugTrackerContext>(options => options.UseSqlServer(connectionString));

            // AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection));

            return services;
        }
    }
}