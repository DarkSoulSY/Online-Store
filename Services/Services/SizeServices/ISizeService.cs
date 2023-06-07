
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.SizeServices
{
    public interface ISizeService
    {
        Task<ServiceResponse<int?>> CreateSize(Size size);
        Task<ServiceResponse<bool?>> DeleteSize(Size size);
        Task<ServiceResponse<Size?>> GetSizeByCondition(Expression<Func<Size, bool>> expressions);
        Task<ServiceResponse<List<Size>?>> GetAllSizes();
        Task<ServiceResponse<int>> UpdateSize(Size size);
    }
}
