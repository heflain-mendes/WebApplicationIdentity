using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.DTOs.Response;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Mapping
{
    public static class EnterpriseMapper
    {
        public static EnterpriseResponse FromEnterpriseToEnterpriseResponse(Enterprise enterprise)
        {
            return new EnterpriseResponse(enterprise.Id, enterprise.Name);
        }

        public static Enterprise FromEnterpriseRequestToEnterprise(EnterpriseRequest request, string ownerId)
        {
            return new Enterprise(request.Name, ownerId);
        }

        public static void UpdateEnterpriseWithEnterpriseRequest(Enterprise enterprise, EnterpriseRequest request)
        {
            enterprise.Name = request.Name;
        }
    }
}
