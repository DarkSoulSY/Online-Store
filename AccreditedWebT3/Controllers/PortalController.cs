using AccreditedWebT3.Models;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.common.UserDto;
using Services.Services.AuthService;

namespace AccreditedWebT3.Controllers
{
    public class PortalController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAuthService _auth;

        public PortalController(IHttpContextAccessor httpContext, IAuthService auth)
        {
            _httpContext = httpContext;
            _auth = auth;
        }

        public async Task<IActionResult> Index(UserLoginModel userLoginModel)
        {
            ServiceResponse<String> response = await _auth.Login(new UserSignInDto() { Username = userLoginModel.Username, Password = userLoginModel.Password});
            
            if (response.Success)
            {
                _httpContext.HttpContext.Session.SetString("Username", userLoginModel.Username);
                _httpContext.HttpContext.Session.SetString("Token", response.Message);

            }

            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }
    }
}
