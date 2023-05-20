using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Identity;
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
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MainCORS", builder =>
                {
                    // Works with internet domains
                    //builder.WithOrigins("http://localhost");

                    // Works with localhost
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            var connectionString = configuration.GetConnectionString("BugTracker");
            services.AddDbContext<BugTrackerContext>(options => options.UseSqlServer(connectionString));

            // Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BugTrackerContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Authentication
            services.Configure<AuthOptions>(
                configuration.GetSection(AuthOptions.SectionName));
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
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = authOptions.Issuer,
                    ValidAudience = authOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyAsBytes)
                };
            });

            return services;
        }

        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection));

            // FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(ServicesConfiguration).Assembly);

            // services.AddCorsPolicy();
            // services.AddAuthentication(configuration);

            // Filters and controllers
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

            return services;
        }
    }
}