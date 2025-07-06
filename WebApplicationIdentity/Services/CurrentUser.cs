namespace WebApplicationIdentity.Services
{
    public record CurrentUser(string Id, string Email, IEnumerable<string> Roles, string? NAtionality, DateOnly? DateOfBirth)
    {
        public bool IsInRole(string RoleName) => Roles.Contains(RoleName);
    }
}
