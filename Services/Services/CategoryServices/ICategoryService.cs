using DataAccessLayer.Models;

namespace Services.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<ServiceResponse<int>> CreateCategory(Category category);
        Task<ServiceResponse<bool?>> DeleteCategory(Category category);
        Task<ServiceResponse<Category>> GetCategoryByCondition(Category category);
        Task<ServiceResponse<List<Category>?>> GetAllCategories();
        Task<ServiceResponse<int>> UpdateCategory(Category category);
    }
}
