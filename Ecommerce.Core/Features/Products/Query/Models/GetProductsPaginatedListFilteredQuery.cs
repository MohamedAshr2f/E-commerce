using Ecommerce.Core.Features.Products.Query.Results;
using Ecommerce.Core.Wrappers;
using Ecommerce.Data.Enums;
using MediatR;

namespace Ecommerce.Core.Features.Products.Query.Models
{
    public class GetProductsPaginatedListFilteredQuery : IRequest<PaginatedResult<GetProductsListResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchWord { get; set; }
        public ProductOrderOptions OrderBy { get; set; } = ProductOrderOptions.Rating_Asc;
    }
}
