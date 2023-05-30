using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.common.User;
using Services.Services.AuthService;

namespace Task3.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly IAuthService _auth;
        

        public PortalController(IAuthService auth)
        {
            _auth = auth;
            
            
        }
        //[AllowAnonymous]
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

        [AllowAnonymous]
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
