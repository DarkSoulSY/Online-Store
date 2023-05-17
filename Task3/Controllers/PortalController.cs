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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ServiceResponse<int?>>> Register([FromBody] UserSignUpDto userSignUpDto)
        {
            var response = await _auth.Register(userSignUpDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] UserSignInDto userSignInDto)
        {
            var response = await _auth.Login(userSignInDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
