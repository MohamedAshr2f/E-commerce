using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Service.Abstracts
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> GetProductByIdWithoutIncludeAsync(int id);
    }
}

