

using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;
using System.Linq.Expressions;

namespace Services.Services.StatusServices
{
    public class StatusService : IStatusService
    {
        private readonly IRepositoryWrapper _wrapper;

        public StatusService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }                

        public Task<ServiceResponse<List<Status>?>> GetAllStatuses()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Status?>> GetStatusByCondition(Expression<Func<Status, bool>> expression)
        {
            var repositoryResponse = await _wrapper.Status.GetSingleStatus(expression);

            if (repositoryResponse is not null)
                return new ServiceResponse<Status?>
                {
                    Data = repositoryResponse,
                    Message = "Retrieved statuses successfully!",
                    Success = true
                };
            else
            {
                return new ServiceResponse<Status?>
                {
                    Data = repositoryResponse,
                    Message = "Could not retrieve statuses successfully!",
                    Success = false
                };
            }



        }

        public async Task<ServiceResponse<int?>> UpdateStatus(Status status)
        {
            _wrapper.Status.UpdateStatus(status);
            await _wrapper.SaveAsync();

            return new ServiceResponse<int?>
            {
                Data = null,
                Message = "Updated status successfully!",
                Success = true
            };
        }
    }
}
