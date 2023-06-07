

using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace Services.Services.StatusServices
{
    public interface IStatusService
    {        
        Task<ServiceResponse<Status?>> GetStatusByCondition(Expression<Func<Status, bool>> expression);
        Task<ServiceResponse<List<Status>?>> GetAllStatuses();
        Task<ServiceResponse<int?>> UpdateStatus(Status status);
    }
}
