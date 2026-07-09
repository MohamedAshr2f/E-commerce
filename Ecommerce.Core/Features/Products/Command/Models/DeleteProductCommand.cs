using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Features.Products.Command.Models
{
    public record DeleteProductCommand(int Id) : IRequest<Response<string>>;
}
