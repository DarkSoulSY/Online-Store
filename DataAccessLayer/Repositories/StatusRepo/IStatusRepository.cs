using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;


namespace DataAccessLayer.Repositories.StatusRepo
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
        Task<List<Status>> GetAllStatuses();
        Task<Status?> GetSingleStatus(Expression<Func<Status, bool>> expression);
        void CreateStatus(Status status);
        void UpdateStatus(Status status);
        void DeleteStatus(Status status);
    }
}
