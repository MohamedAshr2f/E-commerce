using Ecommerce.Core.Features.Products.Query.Results;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        public void GetProductsListMapping()
        {
            CreateMap<Product, GetProductsListResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Photos));
            CreateMap<Photo, ProductImageDto>();


        }
    }
}
