using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationIdentity.Contants;
using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.DTOs.Response;
using WebApplicationIdentity.Services;

namespace WebApplicationIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = UserRoles.Admin)]
    //[Authorize(Policy = PolicyName.HasNationality)]
    [Authorize(Policy = PolicyName.AtLeast20)]
    public class EnterpriseController(IEnterpriseService enterpriseService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await enterpriseService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnterpriseRequest request)
        {
            var response = await enterpriseService.Create(request);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await enterpriseService.Delete(id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnterpriseRequest request)
        {
            await enterpriseService.Update(request, id);

            return NoContent();
        }
    }
}
