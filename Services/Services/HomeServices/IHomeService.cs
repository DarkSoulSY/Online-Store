
using Services.common.HomeControllerDtos;
using Services.common.Item;
using Services.common.SizePrice;

namespace Services.Services.HomeServices
{
    public interface IHomeService
    {
        Task<List<HomeModelDto>> GetHomeModel();
        Task<bool> AddToCart(string? username, int item, string sizeName);

    }
}
