using AutoMapper;

namespace Ecommerce.Core.Mapping.Products
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            GetProductsListMapping();
            GetProductByIdMapping();
        }
    }
}
