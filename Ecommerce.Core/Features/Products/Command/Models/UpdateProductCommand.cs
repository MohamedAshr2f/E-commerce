using Ecommerce.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Core.Features.Products.Command.Models
{
    public class UpdateProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
