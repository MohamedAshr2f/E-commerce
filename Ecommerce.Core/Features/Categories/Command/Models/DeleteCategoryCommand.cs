using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Features.Categories.Command.Models
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
