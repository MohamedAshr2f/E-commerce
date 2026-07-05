using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.InfrastructureBases;

namespace Ecommerce.Infrastructure.Abstracts
{
    public interface ICategoryRepository : IGenericRepositoryAsync<Category>
    {
    }
}
