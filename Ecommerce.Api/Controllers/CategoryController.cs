using Ecommerce.Api.Bases;
using Ecommerce.Core.Features.Categories.Command.Models;
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

        [HttpGet(Router.CategoryRouting.GetByID)]
        public async Task<IActionResult> GetCategoryByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetCategoryByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.CategoryRouting.Create)]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.CategoryRouting.Delete)]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand(id));
            return NewResult(response);
        }

        [HttpPut(Router.CategoryRouting.Edit)]
        public async Task<IActionResult> EditCategory([FromBody] EditCategoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
