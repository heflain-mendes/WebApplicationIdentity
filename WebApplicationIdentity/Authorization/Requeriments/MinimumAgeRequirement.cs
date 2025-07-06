using Microsoft.AspNetCore.Authorization;

namespace WebApplicationIdentity.Authorization.Requeriments
{
    public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
    {
        public int MinimumAge { get; } = minimumAge;
    }
}
