using Ecommerce.Core.Bases;
using MediatR;
using Ecommerce.Core.Features.Categories.Query.Results;

namespace Ecommerce.Core.Features.Categories.Query.Models
{
    public class GetCategoryByIdQuery : IRequest<Response<GetCategoryByIdResponse>>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
