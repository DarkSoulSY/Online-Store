
using DataAccessLayer.Repositories.CartRepo;
using DataAccessLayer.Repositories.UserRepo;
using Services.common.HomeControllerDtos;
using Services.common.Item;
using Services.common.Role;
using Services.common.SizePrice;
using Services.Services.CategoryServices;
using Services.Services.ItemServices;
using Services.Services.ItemSizePriceServices;
using Services.Services.PictureServices;

namespace Services.Services.HomeServices
{
    public class HomeService : IHomeService
    {
        private readonly ICategoryService _category;
        private readonly IPictureService _picture;
        private readonly IItemService _item;
        private readonly IItemSizePriceService _itemSizePrice;
        private readonly ICartRepository _cart;
        private readonly IUserRepository _user;

        public HomeService(ICategoryService category, IPictureService picture, IItemService item, IItemSizePriceService itemSizePrice, ICartRepository cart, IUserRepository user)
        {
            _category = category;
            _picture = picture;
            _item = item;
            _itemSizePrice = itemSizePrice;
            _cart = cart;
            _user = user;
        }

        public async Task AddToCart(string? username)
        {
            if (username is not null)
            {
                var user = await _user.GetSingleUser(U => U.Username == username);
                var existCart = await _cart.GetSingleCart(C => C.UserId == user.Id);
                if (existCart is null) { 
                    _cart.CreateCart(new DataAccessLayer.Models.Cart()
                    {
                        UserId = user.Id
                    });
                }
            }


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
