using Ecommerce.Core.Features.Categories.Command.Models;
using Ecommerce.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Categories.Command.Validations
{
    public class DeleteCategoryValidation : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public DeleteCategoryValidation(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(d => d.Id)
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);
        }
    }
}
