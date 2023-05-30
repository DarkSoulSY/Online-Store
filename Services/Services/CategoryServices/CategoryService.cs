
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;

namespace Services.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _wrapper;

        public CategoryService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        public Task<ServiceResponse<int>> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool?>> DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Category>?>> GetAllCategories()
        {
            var categories = await _wrapper.Category.GetAllCategories();

            if(categories is not null) { 
                return new ServiceResponse<List<Category>?>()
                {
                    Data = categories,
                    Message = "Retrieved all categories successfully!",
                    Success = true
                };
            }
            else

            return new ServiceResponse<List<Category>?>()
            {
                Data = null,
                Message = "Could not find any categories!",
                Success = false
            };
        }

        public Task<ServiceResponse<Category>> GetCategoryByCondition(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
