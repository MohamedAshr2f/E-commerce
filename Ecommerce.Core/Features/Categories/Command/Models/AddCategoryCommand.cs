using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Features.Categories.Command.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
