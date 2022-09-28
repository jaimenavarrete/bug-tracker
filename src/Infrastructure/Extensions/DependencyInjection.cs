using Application.Common;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Common;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITicketService, TicketService>();

            return services;
        }
    }
}