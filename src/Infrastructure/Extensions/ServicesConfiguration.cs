using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            var connectionString = configuration.GetConnectionString("BugTracker");
            services.AddDbContext<BugTrackerContext>(options => options.UseSqlServer(connectionString));

            // Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BugTrackerContext>()
                .AddDefaultTokenProviders();

            // AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection));

            // FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(ServicesConfiguration).Assembly);

            // Authentication
            var authOptions = configuration.GetSection(AuthOptions.SectionName).Get<AuthOptions>();
            var secretKeyAsBytes = Encoding.UTF8.GetBytes(authOptions.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience= true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = authOptions.Issuer,
                    ValidAudience = authOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyAsBytes)
                };
            });

            // Filters and controllers
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

            return services;
        }
    }
}