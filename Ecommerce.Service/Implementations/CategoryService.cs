using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.InfrastructureBases;
using Ecommerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetTableNoTracking().Include(c => c.Products).ThenInclude(p => p.Photos).ToListAsync();
            return categories;

        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetTableNoTracking().Include(c => c.Products).ThenInclude(p => p.Photos).FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<string> AddCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            return "successful";
        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {
            var trans = _unitOfWork.CategoryRepository.BeginTransaction();
            try
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(category);
                trans.Commit();
                return "Deleted";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "failed";
            }
        }

        public Task<Category> GetCategoryByIdWithoutProductsAsync(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetTableNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<string> UpdateCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            return "Successful";
        }
    }
}
