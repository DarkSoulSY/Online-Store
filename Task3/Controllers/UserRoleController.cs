using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.common.UserRoleEntity;
using Services.Services.UserPermissionService;

namespace Task3.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        [Route("GrantRole")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<UserRoleEntity?>>> Grant(UserRoleDto userRoleDto)
        {
            var response = await _userRoleService.GrantRole(userRoleDto);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
