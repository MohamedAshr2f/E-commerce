using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Core.Resources;
using Ecommerce.Data.Entities.Product;
using Ecommerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Products.Command.Handlers
{
    public class ProductCommandHandler : ResponseHandler,
        IRequestHandler<AddProductCommand, Response<string>>,
        IRequestHandler<UpdateProductCommand, Response<string>>
    {
        private readonly IProductService _productService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IMapper _mapper;

        public ProductCommandHandler(IProductService productService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _productService = productService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productMap = _mapper.Map<Product>(request);
            var result = await _productService.AddProductAsync(productMap, request.Images);
            switch (result)
            {
                case "FailedToUploadImage": return BadRequest<string>(_stringLocalizer[SharedResourcesKey.FailedToUploadImage]);
                case "FailedInAdd": return BadRequest<string>(_stringLocalizer[SharedResourcesKey.AddFailed]);
            }
            return Created(result);
        }

        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                return NotFound<string>();
            }
            var del = await _productService.DeleteProductImagesAsync(product);
            if (del == "FailedToDeleteImages")
            {
                return BadRequest<string>("Failed to delete images");
            }
            var productMap = _mapper.Map(request, product);

            var result = await _productService.UpdateProductAsync(productMap, request.Images);
            if (result == "FailedToUploadImage")
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKey.FailedToUploadImage]);
            }
            return Updated("");
        }
    }
}
