using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.common.PermissionDto;
using Services.Services.PermissionService;

namespace Task3.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Permission>?>>> GetAll()
        {
            var response = await _permissionService.GetAllPermissions();
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }
        [AllowAnonymous]
        [HttpGet("GetSingle{name}")]
        public async Task<ActionResult<ServiceResponse<Permission?>>> GetSingle(string name)
        {
            var response = await _permissionService.GetPermissionByName(name);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPost("CreatePermission")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<int>>> CreatePermission([FromBody] PermissionDto permissionDto)
        {
            var response = await _permissionService.CreatePermission(permissionDto);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }
        [HttpDelete("DeletePermission")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<bool?>>> DeletePermission([FromBody] PermissionDto permissionDto)
        {
            var response = await _permissionService.DeletePermission(permissionDto);
            if (response.Success)
            {
                Ok(response);
            }
            return BadRequest(response);

        }

    }
}
