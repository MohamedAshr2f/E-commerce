using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Categories.Query.Models;
using Ecommerce.Core.Features.Categories.Query.Results;
using Ecommerce.Core.Resources;
using Ecommerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Categories.Query.Handler
{
    public class CategoryQueryHandler : ResponseHandler, IRequestHandler<GetCategoriesListQuery, Response<List<GetCategoriesListResponse>>>, IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public CategoryQueryHandler(ICategoryService categoryService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetCategoriesListResponse>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoriesListmapping = _mapper.Map<List<GetCategoriesListResponse>>(categories);
            return Success(categoriesListmapping);
        }

        public async Task<Response<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            if (category == null) return NotFound<GetCategoryByIdResponse>();
            var mapped = _mapper.Map<GetCategoryByIdResponse>(category);
            return Success(mapped);
        }
    }
}
