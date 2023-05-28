using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.SizeRepo
{
    public interface ISizeRepository : IRepositoryBase<Size>
    {
        Task<List<Size>> GetAllSizes();
        Task<Size?> GetSingleSize(Expression<Func<Size, bool>> expression);
        void CreateSize(Size size);
        void UpdateSize(Size size);
        void DeleteSize(Size size);
    }
}
