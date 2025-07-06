using WebApplicationIdentity.DTOs.Request;

namespace WebApplicationIdentity.Services
{
    public interface IUserService
    {
        public Task UpdateUserDetails(UserUpdateDetailsRequest request, CancellationToken cancellationToken);
        public Task AssignUserRole(AssignUserRoleRequest request);
    }
}
