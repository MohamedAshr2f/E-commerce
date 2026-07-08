using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        public void AddProductMapping()
        {
            CreateMap<AddProductCommand, Product>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore());
        }
    }
}
