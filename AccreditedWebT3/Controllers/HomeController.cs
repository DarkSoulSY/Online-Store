using AccreditedWebT3.Models;
using Microsoft.AspNetCore.Mvc;
using Services.common.Item;
using Services.common.SizePrice;
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
        /*
         User Visits home page:

            He sees items, 

            *** Add to Cart does not work unless he selected a size for that specific item ***
            Then,

            1- Clicks on Add Cart
            2- Sends item + size to controller, 
            3- Controller sends item + size + username 
            4- Home Service then creates a new order *if* an order with status false does not already exists
            5- binds ItemSizePriceOrder with current Order
        */
        [HttpPost]
        public async Task<bool> AddToCart([FromBody] int item, [FromBody] string size /*AddToCartModel model*/)
        {
            var addItem =  await _home.AddToCart(_httpContext.HttpContext!.Session.GetString("Username"), item, size);

            return addItem;
        }
    }
}
