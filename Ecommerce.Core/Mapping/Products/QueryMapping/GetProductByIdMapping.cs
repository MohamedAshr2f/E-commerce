using Ecommerce.Core.Features.Products.Query.Models;
using Ecommerce.Core.Features.Products.Query.Results;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        public void GetProductByIdMapping()
        {
            CreateMap<Product, GetProductByIdResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.images, opt => opt.MapFrom(src => src.Photos));

            CreateMap<Photo, ProductImageDto>();
        }
    }
}
