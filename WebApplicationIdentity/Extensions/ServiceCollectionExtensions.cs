using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Authorization;
using WebApplicationIdentity.Authorization.Requeriments;
using WebApplicationIdentity.Authorization.Services;
using WebApplicationIdentity.Contants;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.Models;
using WebApplicationIdentity.Services;

namespace WebApplicationIdentity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WebApplicationIdentityDbContext>(options =>
                options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<WebApplicationUserClaimPrincipalFactory>()
                .AddEntityFrameworkStores<WebApplicationIdentityDbContext>();
        }

        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IEnterpriseAuthorizationService, EnterpriseAuthorizationService>();

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyName.HasNationality, builder => builder.RequireClaim(WebApplicationClaimTypes.Nationality, "Brasil", "German"))
                .AddPolicy(PolicyName.AtLeast20, buider => buider.AddRequirements(new MinimumAgeRequirement(20)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        }
    }
}