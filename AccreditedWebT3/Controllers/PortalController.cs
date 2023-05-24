using AccreditedWebT3.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccreditedWebT3.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }
    }
}
