using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Categories.Query.Results;
using MediatR;

namespace Ecommerce.Core.Features.Categories.Query.Models
{
    public class GetCategoriesListQuery : IRequest<Response<List<GetCategoriesListResponse>>>
    {

    }
}
