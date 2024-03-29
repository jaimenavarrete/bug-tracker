﻿using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
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
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProjectStateService, ProjectStateService>();
            services.AddTransient<IProjectTagService, ProjectTagService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITicketStateService, TicketStateService>();
            services.AddTransient<ITicketTagService, TicketTagService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILookupDataService, LookupDataService>();

            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}