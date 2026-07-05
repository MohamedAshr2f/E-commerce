using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.Abstracts;
using Ecommerce.Infrastructure.ApplicationContext;
using Ecommerce.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(Context context) : base(context)
        {
            _products = context.Set<Product>();
        }
    }
}
