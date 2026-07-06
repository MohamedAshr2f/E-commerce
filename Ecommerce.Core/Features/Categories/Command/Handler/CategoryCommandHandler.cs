using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Core.Resources;
using Ecommerce.Data.Entities.Product;
using Ecommerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Categories.Command.Handler
{
    public class CategoryCommandHandler : ResponseHandler, IRequestHandler<AddCategoryCommand, Response<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(ICategoryService categoryService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;

        }

        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var categorymap = _mapper.Map<Category>(request);

            var result = await _categoryService.AddCategoryAsync(categorymap);
            if (result == "successful")
            {
                return Created(result);
            }
            return BadRequest<string>();
        }
    }
}
