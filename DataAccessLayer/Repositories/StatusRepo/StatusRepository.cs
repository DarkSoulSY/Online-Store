using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.StatusRepo
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {

        public StatusRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }
        public void CreateStatus(Status status)
        {
            Create(status);
        }

        public void DeleteStatus(Status status)
        {
            Delete(status);
        }

        public async Task<List<Status>> GetAllStatuses()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Status?> GetSingleStatus(Expression<Func<Status, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }      

        public void UpdateStatus(Status status)
        {
            Update(status);
        }
    }
}
