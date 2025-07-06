using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.DTOs.Response;

namespace WebApplicationIdentity.Services
{
    public interface IEnterpriseService
    {
        public Task<EnterpriseResponse> Create(EnterpriseRequest request);
        public Task Update(EnterpriseRequest request, int entrepriseId);
        public Task Delete(int enterpriseId);
        public Task<EnterpriseResponse> GetById(int enterpriseId);
    }
}
