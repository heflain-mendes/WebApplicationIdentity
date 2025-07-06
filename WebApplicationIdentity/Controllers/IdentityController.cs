using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationIdentity.Contants;
using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.Services;

namespace WebApplicationIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UserUpdateDetailsRequest request, [FromServices] IUserService service, CancellationToken cancellationToken = default)
        {
            await service.UpdateUserDetails(request, cancellationToken);

            return NoContent();   
        }

        [HttpPost("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole([FromBody] AssignUserRoleRequest request, [FromServices] IUserService service)
        {
            await service.AssignUserRole(request);

            return NoContent();
        }
    }
}
