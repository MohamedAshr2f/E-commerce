using Ecommerce.Core.Features.Products.Query.Results;

namespace Ecommerce.Core.Features.Products.Query.Models
{
    public class GetProductByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public double Rating { get; set; }
        public string CategoryName { get; set; }
        public List<ProductImageDto> images { get; set; }
    }

}
