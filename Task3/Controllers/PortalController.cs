using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using Microsoft.AspNetCore.Mvc;
using Services.common.UserDto;
using Services.Services.AuthService;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly IAuthService _auth;
        

        public PortalController(IAuthService auth)
        {
            _auth = auth;
            
            
        }

        [HttpPost("Register")]
        
        public async Task<ActionResult<ServiceResponse<int?>>> Register([FromBody] UserSignUpDto userSignUpDto)
        {
            return Ok(await _auth.Register(userSignUpDto));
        }
        
    }
}
