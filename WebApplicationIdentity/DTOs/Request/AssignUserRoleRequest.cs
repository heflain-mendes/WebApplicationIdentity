namespace WebApplicationIdentity.DTOs.Request
{
    public class AssignUserRoleRequest
    {
        public string UserEmail { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
