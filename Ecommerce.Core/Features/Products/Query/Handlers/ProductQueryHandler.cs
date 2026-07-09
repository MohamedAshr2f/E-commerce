using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Products.Query.Models;
using Ecommerce.Core.Features.Products.Query.Results;
using Ecommerce.Core.Resources;
using Ecommerce.Core.Wrappers;
using Ecommerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Products.Query.Handlers
{
    public class ProductQueryHandler : ResponseHandler,
        IRequestHandler<GetProductsListQuery, Response<List<GetProductsListResponse>>>,
        IRequestHandler<GetProductsSortedQuery, Response<List<GetProductsListResponse>>>,
        IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>,
        IRequestHandler<GetProductsPaginatedListFilteredQuery, PaginatedResult<GetProductsListResponse>>
    {
        private readonly IProductService _productService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductService productService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _productService = productService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<List<GetProductsListResponse>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();
            var response = _mapper.Map<List<GetProductsListResponse>>(products);
            return Success(response);
        }

        public async Task<Response<List<GetProductsListResponse>>> Handle(GetProductsSortedQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetSortedProductsAsync(request.SortBy, request.CategoryId);
            var response = _mapper.Map<List<GetProductsListResponse>>(products);
            return Success(response);
        }

        public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                return NotFound<GetProductByIdResponse>();
            }
            var response = _mapper.Map<GetProductByIdResponse>(product);
            return Success(response);
        }

        public async Task<PaginatedResult<GetProductsListResponse>> Handle(GetProductsPaginatedListFilteredQuery request, CancellationToken cancellationToken)
        {
            var query = _productService.FilterProductPaginatedQueryable(request.SearchWord, request.OrderBy);
            var projectedQuery = await _mapper.ProjectTo<GetProductsListResponse>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return projectedQuery;
        }
    }
}
