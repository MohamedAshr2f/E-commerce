namespace Ecommerce.Core.Features.Categories.Query.Results
{
    public class GetCategoriesListResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDtos> Products { get; set; }
    }
    public class ProductDtos
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public double Rating { get; set; }
    }
}
