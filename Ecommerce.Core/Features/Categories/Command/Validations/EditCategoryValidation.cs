using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Categories.Command.Validations
{
    public class EditCategoryValidation : AbstractValidator<EditCategoryCommand>
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public EditCategoryValidation(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(d => d.Id)
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);

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
