using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, string connectionString)
        {
            // Filters
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

            // Database
            services.AddDbContext<BugTrackerContext>(options => options.UseSqlServer(connectionString));

            // AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection));

            // FluentValidation
           services.AddFluentValidationAutoValidation();
           services.AddValidatorsFromAssembly(typeof(ServicesConfiguration).Assembly);

            return services;
        }
    }
}