using Ecommerce.Core.Features.Categories.Query.Results;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Catogories
{
    public partial class CategoryProfile
    {
        public void GetCategoryByIdMapping()
        {
            CreateMap<Category, GetCategoryByIdResponse>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<Product, ProductDtos>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));


        }
    }
}
