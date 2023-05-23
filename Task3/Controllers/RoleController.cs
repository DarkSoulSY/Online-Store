using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.common.RoleDto;
using Services.Services.RoleService;

namespace Task3.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Role>?>>> GetAll()
        {
            var response = await _roleService.GetAllRoles();
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }
        [AllowAnonymous]
        [HttpGet("GetSingle{name}")]
        public async Task<ActionResult<ServiceResponse<Role?>>> GetSingle(string name)
        {           
            var response = await _roleService.GetRoleByName(name);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("CreateRole")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<int>>> CreateRole([FromBody] RoleDto roleDto)
        {
            var response = await _roleService.CreateRole(roleDto);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }
        [HttpDelete("DeleteRole")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<bool?>>> DeleteRole([FromBody] RoleDto roleDto)
        {
            var response = await _roleService.DeleteRole(roleDto);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }

        
    }
}
