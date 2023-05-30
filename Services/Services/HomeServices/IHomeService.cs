
using Services.common.HomeControllerDtos;

namespace Services.Services.HomeServices
{
    public interface IHomeService
    {
        Task<List<HomeModelDto>> GetHomeModel();
        Task AddToCart(string? username);

    }
}
