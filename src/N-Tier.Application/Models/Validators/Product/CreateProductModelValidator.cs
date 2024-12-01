using FluentValidation;
using N_Tier.Application.Models.ProductModels;

namespace N_Tier.Application.Models.Validators.Product
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(ProductValidatorConfiguration.MinimumNameLenth)
                .WithMessage(
                    $"Product name should have minimum ${ProductValidatorConfiguration.MinimumNameLenth} characters")
                .MaximumLength(ProductValidatorConfiguration.MaximumNameLength)
                .WithMessage(
                    $"Product name should have maximum {ProductValidatorConfiguration.MaximumNameLength} characters");
        }
    }
}
