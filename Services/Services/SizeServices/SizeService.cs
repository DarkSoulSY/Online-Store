
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System.Linq.Expressions;

namespace Services.Services.SizeServices
{
    public class SizeService : ISizeService
    {
        private readonly IRepositoryWrapper _wrapper;

        public SizeService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        public Task<ServiceResponse<int?>> CreateSize(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool?>> DeleteSize(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Size>?>> GetAllSizes()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Size?>> GetSizeByCondition(Expression<Func<Size, bool>> expressions)
        {
            var response = await _wrapper.Size.GetSingleSize(expressions);

            if (response is not null)
            {
                return new ServiceResponse<Size?>
                {
                    Data = response,
                    Message = "Retrieved size successfully",
                    Success = true
                };
            }
            else
                return new ServiceResponse<Size?>
                {
                    Data = response,
                    Message = "could not retrieve size!",
                    Success = false
                };
        }

        public Task<ServiceResponse<int>> UpdateSize(Size size)
        {
            throw new NotImplementedException();
        }
    }
}
