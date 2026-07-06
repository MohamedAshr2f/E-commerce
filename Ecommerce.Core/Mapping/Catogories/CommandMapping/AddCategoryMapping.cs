using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Data.Entities.Product;

namespace Ecommerce.Core.Mapping.Catogories
{
    public partial class CategoryProfile
    {
        public void AddCategoryMapping()
        {
            CreateMap<AddCategoryCommand, Category>();
        }
    }
}
