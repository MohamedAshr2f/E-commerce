using Ecommerce.Api.Bases;
using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Core.Features.Products.Query.Models;
using Ecommerce.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class ProductController : AppController
    {
        [HttpGet(Router.ProductRouting.List)]

        public async Task<IActionResult> GetProducts()
        {
            var response = await Mediator.Send(new GetProductsListQuery());
            return NewResult(response);
        }

        [HttpGet(Router.ProductRouting.GetByID)]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetProductByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.ProductRouting.Create)]
        public async Task<IActionResult> AddProduct([FromForm] AddProductCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.ProductRouting.Update)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ProductRouting.Delete)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }
    }
}

