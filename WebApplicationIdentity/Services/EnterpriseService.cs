using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Authorization.Services;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.DTOs.Response;
using WebApplicationIdentity.Mapping;

namespace WebApplicationIdentity.Services
{
    public class EnterpriseService(
        WebApplicationIdentityDbContext dbContext,
        IUserContext userContext, 
        IEnterpriseAuthorizationService enterpriseAuthorization) : IEnterpriseService
    {
        public async Task<EnterpriseResponse> Create(EnterpriseRequest request)
        {
            var user = userContext.GetCurrentUser();

            var enterprise = EnterpriseMapper.FromEnterpriseRequestToEnterprise(request, user!.Id);

            if (!enterpriseAuthorization.Authorize(enterprise, Authorization.ResourceOperation.Create))
                throw new Exception("Não autorizado!!!");

            dbContext.Enterprises.Add(enterprise);
            await dbContext.SaveChangesAsync();

            return EnterpriseMapper.FromEnterpriseToEnterpriseResponse(enterprise);
        }

        public async Task Update(EnterpriseRequest request, int entrepriseId)
        {
            var enterprise = await dbContext.Enterprises.FirstOrDefaultAsync(e => e.Id.Equals(entrepriseId));

            if (enterprise == null)
                throw new Exception("Não foi possível encontrar a Enterprise");

            if (!enterpriseAuthorization.Authorize(enterprise, Authorization.ResourceOperation.Update))
                throw new Exception("Não autorizado!!!");

            EnterpriseMapper.UpdateEnterpriseWithEnterpriseRequest(enterprise, request);

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int enterpriseId)
        {
            var enterprise = await dbContext.Enterprises.FirstOrDefaultAsync(e => e.Id.Equals(enterpriseId));

            if (enterprise == null)
                throw new Exception("Enterprise não existe");

            if (!enterpriseAuthorization.Authorize(enterprise, Authorization.ResourceOperation.Delete))
                throw new Exception("Não autorizado!!!");

            dbContext.Remove(enterprise);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EnterpriseResponse> GetById(int enterpriseId)
        {
            var enterprise = await dbContext.Enterprises.FirstOrDefaultAsync(e => e.Id.Equals(enterpriseId));

            if (enterprise == null)
                throw new Exception("Enterprise não existe");

            if (!enterpriseAuthorization.Authorize(enterprise, Authorization.ResourceOperation.Read))
                throw new Exception("Não autorizado!!!");

            return EnterpriseMapper.FromEnterpriseToEnterpriseResponse(enterprise);
        }
    }
}
