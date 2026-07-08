using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        public void UpdateProductMapping()
        {
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore()).ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
