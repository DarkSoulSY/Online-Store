using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.CategoryRepo
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetSingleCategory(Expression<Func<Category, bool>> expression);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
