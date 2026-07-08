using Ecommerce.Core.Features.Products.Command.Models;
using Ecommerce.Core.Resources;
using Ecommerce.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Core.Features.Products.Command.Validations
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IFileService _fileService;

        public UpdateProductValidation(IStringLocalizer<SharedResource> stringLocalizer, IFileService fileService)
        {
            _stringLocalizer = stringLocalizer;
            _fileService = fileService;
            ApplyValidationRules();
            ApplyCustomValidationsRules();
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
                .MaximumLength(500).WithMessage(_stringLocalizer[SharedResourcesKey.MaxLengthis100]);

            RuleFor(d => d.NewPrice)
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(d => d.OldPrice)
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(d => d.CategoryId)
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKey.IsNotExist]);
        }

        private async void ApplyCustomValidationsRules()
        {
            RuleFor(d => d.Images)
                .Custom(async (images, context) =>
                {
                    if (images != null && images.Count > 0)
                    {
                        foreach (var file in images)
                        {
                            var isValidExtension = await _fileService.IsValidImageFileExtension(file);
                            if (!isValidExtension)
                            {
                                context.AddFailure(_stringLocalizer[SharedResourcesKey.InvaildImageExtension]);
                            }

                            var isValidLength = await _fileService.IsValidImageFileMaxLength(file);
                            if (!isValidLength)
                            {
                                context.AddFailure(_stringLocalizer[SharedResourcesKey.InvaildImageSize]);
                            }
                        }
                    }
                });
        }
    }
}
