namespace Ecommerce.Core.Features.Products.Query.Results
{
    public class GetProductsListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public double Rating { get; set; }
        public string CategoryName { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
    }
}
