using Ecommerce.Data.Entities.Product;
using Ecommerce.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Service.Abstracts
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<List<Product>> GetSortedProductsAsync(string? sortBy, int? CategoryId);
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> GetProductByIdWithoutIncludeAsync(int id);
        public Task<string> AddProductAsync(Product product, IFormFileCollection images);
        public Task<string> UpdateProductAsync(Product product, IFormFileCollection images);
        public Task<string> DeleteProductImagesAsync(Product product);
        public Task<string> DeleteProductAsync(Product product);
        public IQueryable<Product> GetProductQueryable();
        public IQueryable<Product> FilterProductPaginatedQueryable(string searchWord, ProductOrderOptions orderBy);
    }
}

