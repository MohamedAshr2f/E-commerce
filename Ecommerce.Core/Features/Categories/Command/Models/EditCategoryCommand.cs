using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Features.Categories.Command.Models
{
    public class EditCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
