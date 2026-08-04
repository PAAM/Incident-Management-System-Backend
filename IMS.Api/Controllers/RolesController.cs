using IMS.Core.Dtos;
using IMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IMS.Core.Authorization;

namespace IMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IUserService _userService;
        public RolesController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Policy = Permissions.RoleRead)]
        [HttpGet("{roleId:int}/users")]
        public async Task<ActionResult<IReadOnlyList<UserByRoleDto>>> GetUsersByRole(int roleId)
        {
            if (roleId <= 0)
            { 
                return BadRequest("RoleId must be greater than zero.");
            }
            var users = await _userService.GetUsersByRoleAsync(roleId);
            return Ok(users);
        }
    }
}
