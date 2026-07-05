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
            var categories = await _unitOfWork.CategoryRepository.GetTableNoTracking().Include(c => c.Products).ToListAsync();
            return categories;

        }
    }
}
