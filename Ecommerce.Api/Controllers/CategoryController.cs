using Ecommerce.Api.Bases;
using Ecommerce.Core.Features.Categories.Query.Models;
using Ecommerce.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{

    [ApiController]
    public class CategoryController : AppController
    {
        [HttpGet(Router.CategoryRouting.List)]
        public async Task<IActionResult> GetCategories()
        {
            var response = await Mediator.Send(new GetCategoriesListQuery());
            return NewResult(response);
        }
    }
}
