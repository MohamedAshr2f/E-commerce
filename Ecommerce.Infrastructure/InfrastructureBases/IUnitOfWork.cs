using Ecommerce.Infrastructure.Abstracts;

namespace Ecommerce.Infrastructure.InfrastructureBases
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
    }
}
