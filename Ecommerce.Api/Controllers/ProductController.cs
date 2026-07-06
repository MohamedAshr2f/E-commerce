using Ecommerce.Api.Bases;
using Ecommerce.Core.Features.Products.Query.Models;
using Ecommerce.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
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
    }
}
