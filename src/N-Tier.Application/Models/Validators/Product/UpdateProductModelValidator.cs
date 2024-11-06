using FluentValidation;
using N_Tier.Application.Models.Product;
using N_Tier.Application.Models.Validators.TodoItem;

namespace N_Tier.Application.Models.Validators.Product
{
    public class UpdateProductModelValidator :AbstractValidator<UpdateProductModel>
    {
        public UpdateProductModelValidator()
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
