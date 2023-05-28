using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.SizeRepo
{
    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        public SizeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }

        public void CreateSize(Size size)
        {
            Create(size);
        }

        public void DeleteSize(Size size)
        {
            Delete(size);
        }

        public async Task<List<Size>> GetAllSizes()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Size?> GetSingleSize(Expression<Func<Size, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdateSize(Size size)
        {
            Update(size);
        }
    }
}
