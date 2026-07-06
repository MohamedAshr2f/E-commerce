using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Products.Query.Results;
using MediatR;

namespace Ecommerce.Core.Features.Products.Query.Models
{
    public class GetProductsListQuery : IRequest<Response<List<GetProductsListResponse>>>
    {
    }
}
