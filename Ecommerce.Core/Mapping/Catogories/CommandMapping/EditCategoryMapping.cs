using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Catogories
{
    public partial class CategoryProfile
    {
        public void EditCategoryMapping()
        {
            CreateMap<EditCategoryCommand, Category>().ForMember(dest => dest.Id, op => op.MapFrom(src => src.Id));
        }
    }
}
