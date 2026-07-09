using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Core.Resources;
using Ecommerce.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Products.Command.Validations
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IProductService _productService;

        public DeleteProductValidation(
            IStringLocalizer<SharedResource> stringLocalizer,
            IProductService productService)
        {
            _stringLocalizer = stringLocalizer;
            _productService = productService;
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.Required]);

            RuleFor(d => d.Id)
                .MustAsync(async (id, ct) => await _productService.GetProductByIdAsync(id) != null)
                .WithMessage(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
    }
}
