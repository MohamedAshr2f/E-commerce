using Ecommerce.Data.Entities.Product;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Service.Abstracts
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> GetProductByIdWithoutIncludeAsync(int id);
        public Task<string> AddProductAsync(Product product, IFormFileCollection images);
        public Task<string> UpdateProductAsync(Product product, IFormFileCollection images);
        public Task<string> DeleteProductImagesAsync(Product product);
    }
}

