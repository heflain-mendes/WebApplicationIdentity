using System.Net;
using System.Security.Claims;
using WebApplicationIdentity.Contants;

namespace WebApplicationIdentity.Services
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;

            if (user == null)
                throw new InvalidOperationException("User is not present");

            if(user.Identity == null || !user.Identity.IsAuthenticated)
                return null;


            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type != ClaimTypes.Email)!.Value;
            var role = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
            var nationality = user.FindFirst(c => c.Type == WebApplicationClaimTypes.Nationality)!.Value;
            var dateOfBirthString = user.FindFirst(c => c.Type == WebApplicationClaimTypes.DateOfBirth)!.Value;
            var dateOfBirth = dateOfBirthString == null ? (DateOnly?) null : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd"); 

            return new CurrentUser(userId, email, role, nationality, dateOfBirth);
        }
    }   
}
