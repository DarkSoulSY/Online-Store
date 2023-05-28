using Microsoft.AspNetCore.Mvc;

namespace AccreditedWebT3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
