using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Authorization.Services
{
    public interface IEnterpriseAuthorizationService
    {
        bool Authorize(Enterprise enterprise, ResourceOperation operation);
    }
}