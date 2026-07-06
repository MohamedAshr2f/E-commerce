using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Core.Resources;
using Ecommerce.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;


namespace Ecommerce.Core.Features.Categories.Command.Validations
{
    public class AddCategoryValidation : AbstractValidator<AddCategoryCommand>
    {

        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly ICategoryService _categoryService;
        public AddCategoryValidation(IStringLocalizer<SharedResource> stringLocalizer, ICategoryService categoryService)
        {
            _stringLocalizer = stringLocalizer;
            _categoryService = categoryService;
            ApplyValidationRules();

        }

        private void ApplyValidationRules()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

            RuleFor(d => d.Description)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKey.Required])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);


        }


    }
}
