﻿using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<IProjectRepository, ProjectRepository>();

            // Services
            services.AddTransient<IProjectService, ProjectService>();

            return services;
        }
    }
}