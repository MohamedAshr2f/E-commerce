using Ecommerce.Infrastructure.Abstracts;
using Ecommerce.Infrastructure.ApplicationContext;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Infrastructure.InfrastructureBases
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }
        public UnitOfWork(Context context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            PhotoRepository = new PhotoRepository(_context);
        }
    }
}
