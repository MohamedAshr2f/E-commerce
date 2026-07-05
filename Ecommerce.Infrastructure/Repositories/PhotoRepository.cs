using Ecommerce.Data.Entities.Product;
using Ecommerce.Infrastructure.Abstracts;
using Ecommerce.Infrastructure.ApplicationContext;
using Ecommerce.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class PhotoRepository : GenericRepositoryAsync<Photo>, IPhotoRepository
    {
        private readonly DbSet<Photo> _photos;
        public PhotoRepository(Context context) : base(context)
        {
            _photos = context.Set<Photo>();
        }
    }
}
