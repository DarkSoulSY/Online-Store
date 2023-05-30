using AccreditedWebT3.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.CategoryServices;
using Services.Services.HomeServices;
using Services.Services.ItemServices;
using Services.Services.PictureServices;

namespace AccreditedWebT3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _home;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(IHomeService home, IHttpContextAccessor httpContext)
        {
            _home = home;
            _httpContext = httpContext;
        }
        public async Task<IActionResult> Home()
        {
            var list = await _home.GetHomeModel();
            var mappedList = list.Select(model => new Home()
            {
                Category = model.Category,
                CategoryItems = model.Items
            }).ToList();

            return View(mappedList);
        }

        public async Task AddToCart()
        {
            await _home.AddToCart(_httpContext.HttpContext.Session.GetString("Username"));
        }
    }
}
