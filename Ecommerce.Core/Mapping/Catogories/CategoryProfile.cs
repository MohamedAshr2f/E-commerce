using AutoMapper;

namespace Ecommerce.Core.Mapping.Catogories
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            GetCategoryListMapping();
        }
    }
}
