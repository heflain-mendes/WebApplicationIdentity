using WebApplicationIdentity.Contants;
using WebApplicationIdentity.Models;
using WebApplicationIdentity.Services;

namespace WebApplicationIdentity.Authorization.Services
{
    public class EnterpriseAuthorizationService(IUserContext userContext) : IEnterpriseAuthorizationService
    {
        public bool Authorize(Enterprise enterprise, ResourceOperation operation)
        {
            var user = userContext.GetCurrentUser();

            if (operation == ResourceOperation.Read || operation == ResourceOperation.Create)
                return true;

            if (operation == ResourceOperation.Delete && user!.IsInRole(UserRoles.Admin))
                return true;

            if ((operation == ResourceOperation.Delete || operation == ResourceOperation.Create)
                && user!.Id == enterprise.OwnerId)
                return true;

            return false;
        }
    }
}
