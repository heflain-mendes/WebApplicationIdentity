using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApplicationIdentity.Contants;

namespace WebApplicationIdentity.Data.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(WebApplicationIdentityDbContext context)
        {
            if (!context.Roles.Any())
            {
                List<IdentityRole> roles = [
                    new IdentityRole(UserRoles.Admin),
                    new IdentityRole (UserRoles.User),
                ];

                roles.ForEach(item => item.NormalizedName = item.Name!.ToUpper() ?? null);

                context.Roles.AddRange(roles);

                await context.SaveChangesAsync();
            }
        }
    }
}
