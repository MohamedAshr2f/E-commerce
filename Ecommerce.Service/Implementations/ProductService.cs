using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.InfrastructureBases;
using Ecommerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsSplitQuery()
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsSplitQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> GetProductByIdWithoutIncludeAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
    }
}
