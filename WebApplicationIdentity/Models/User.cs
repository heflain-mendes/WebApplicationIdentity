using Microsoft.AspNetCore.Identity;

namespace WebApplicationIdentity.Models
{
    public class User : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        public List<Enterprise> Enterprises { get; set; } = [];
    }
}
