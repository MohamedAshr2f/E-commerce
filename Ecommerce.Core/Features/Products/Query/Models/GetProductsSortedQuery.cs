using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Products.Query.Results;
using MediatR;

namespace Ecommerce.Core.Features.Products.Query.Models
{
    public class GetProductsSortedQuery : IRequest<Response<List<GetProductsListResponse>>>
    {
        public string? SortBy { get; set; }
        public int? CategoryId { get; set; }

    }
}
