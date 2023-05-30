using AccreditedWebT3.Models;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.common.User;
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

        public IActionResult LogIn()
        {
            if (CheckSession())
                RedirectToAction("Home", "Home");
            return View();

        }

        public async Task<IActionResult> CheckUserCredentials(UserLoginModel userLoginModel)
        {
            ServiceResponse<String> response = await _auth.Login(new UserSignInDto() { Username = userLoginModel.Username, Password = userLoginModel.Password });

            if (response.Success)
            {
                _httpContext.HttpContext!.Session.SetString("Username", userLoginModel.Username);
                _httpContext.HttpContext.Session.SetString("Token", response.Message);
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("LogIn", "Portal");

        }

        public bool CheckSession()
        {
            if (_httpContext.HttpContext!.Session.GetString("Username") is not null && _httpContext.HttpContext.Session.GetString("Token") is not null)
            {
                return true;
            }
            else
                return false;
        }

        public IActionResult Register() 
        {
            return View();
        }
    }
}
