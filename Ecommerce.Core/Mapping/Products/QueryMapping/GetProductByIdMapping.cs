using Ecommerce.Core.Features.Products.Query.Models;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        public void GetProductByIdMapping()
        {
            CreateMap<Product, GetProductByIdResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));

            CreateMap<Photo, PhotoResponse>();
        }
    }
}
