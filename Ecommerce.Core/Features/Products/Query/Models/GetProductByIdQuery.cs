using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Features.Products.Query.Models
{
    public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
