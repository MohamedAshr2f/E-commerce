using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Service.Abstracts
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category?> GetCategoryByIdAsync(int id);
        public Task<string> AddCategoryAsync(Category category);
        public Task<Category> GetCategoryByIdWithoutProductsAsync(int id);
        public Task<string> DeleteCategoryAsync(Category category);
    }
}
