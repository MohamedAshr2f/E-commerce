using Ecommerce.Core.Features.Products.Query.Results;

namespace Ecommerce.Core.Features.Categories.Query.Results
{
    public class GetCategoryByIdResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetProductsListResponse> Products { get; set; }
    }
}
