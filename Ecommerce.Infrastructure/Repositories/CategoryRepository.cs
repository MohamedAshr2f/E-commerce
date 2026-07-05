using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.Abstracts;
using Ecommerce.Infrastructure.ApplicationContext;
using Ecommerce.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        public CategoryRepository(Context context) : base(context)
        {
            _categories = context.Set<Category>();
        }
    }
}
