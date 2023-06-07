using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Services.common.HomeControllerDtos;
using Services.common.Item;
using Services.common.SizePrice;
using Services.Services.CartServices;
using Services.Services.CategoryServices;
using Services.Services.ItemServices;
using Services.Services.ItemSizePriceOrderServices;
using Services.Services.ItemSizePriceSizePriceServices;
using Services.Services.OrderServices;
using Services.Services.PictureServices;
using Services.Services.SizeServices;
using Services.Services.UserServices;

namespace Services.Services.HomeServices
{
    public class HomeService : IHomeService
    {
        private readonly ICategoryService _category;
        private readonly IPictureService _picture;
        private readonly IItemService _item;
        private readonly IItemSizePriceService _itemSizePrice;
        private readonly ICartService _cart;
        private readonly IUserService _user;
        private readonly IOrderService _order;
        private readonly IItemSizePriceOrderService _itemSizePriceOrder;
        private readonly ISizeService _size;

        public HomeService(ICategoryService category, IPictureService picture, IItemService item, 
            IItemSizePriceService itemSizePrice, ICartService cart, IUserService user, 
            IOrderService order, IItemSizePriceOrderService itemSizePriceOrder)
        {
            _category = category;
            _picture = picture;
            _item = item;
            _itemSizePrice = itemSizePrice;
            _cart = cart;
            _user = user;
            _order = order;
            _itemSizePriceOrder = itemSizePriceOrder;
        }

        public async Task<bool> AddToCart(string? username, int item, string sizeName)
        {
            var cart = await _user.GetUserByCondition(U => U.Username == username);
            var checkOrderStatus = await _order.GetOrderByCondition(O => O.Status.Submitted == false && O.Cart == cart.Data!.Cart);
            
            if (checkOrderStatus.Data is null)
            {
                var order = await _order.CreateOrder(new Order() {
                    CartId = cart.Data!.Cart.Id
                });
                checkOrderStatus = order;
            }
            var isp = await _itemSizePrice.GetItemSizePriceByCondition(ISP => ISP.Item.Id == item && ISP.Size.Name == sizeName);
            var create = await _itemSizePriceOrder.CreateItemSizePriceOrder(new ItemSizePriceOrder
            {
                Order = checkOrderStatus.Data!,
                ItemSizePrice = isp.Data!
            });
            if (create.Success)
                return true;
            else 
                return false;
        }
        public async Task<List<HomeModelDto>> GetHomeModel()
        {
            var categories = await _category.GetAllCategories();
            var items = await _item.GetAllItems();
            var pictures = await _picture.GetAllPictures();
            var itemSizePrices = await _itemSizePrice.GetAllItemSizePrice();


            var homes = categories.Data!.Select(category => new HomeModelDto
            {
                Category = category.Name,
                Items = items.Data!
                    .Where(item => item.CategoryId == category.Id)
                    .Select(item => new ItemDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        PictureURL = pictures.Data!
                        .Where(picture => picture.ItemId == item.Id)
                        .FirstOrDefault()!.Url,
                        
                        SizePrice = itemSizePrices.Data.Where(E => E.ItemId == item.Id)
                        .Select(E => new SizePriceDto()
                        {
                            Name = E.Size.Name,
                            Price = E.Price
                        })
                        .ToList() 
                    })
                    .ToList()
            }).ToList(); 
            

            return homes;
        }
    }
}
