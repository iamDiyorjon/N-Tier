using FluentValidation;
using N_Tier.Application.Models.CustomerModels;
using N_Tier.Application.Models.Validators.Product;

namespace N_Tier.Application.Models.Validators.Customer
{
    public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerModelValidator()
        {
            //RuleFor(c => c.Name).NotEmpty()
            //    .MinimumLength(CustomerValidatorConfiguration.MinimumNameLenth)
            //        .WithMessage($"Customer name should have minimum ${ProductValidatorConfiguration.MinimumNameLenth} characters")
            //    .MaximumLength(CustomerValidatorConfiguration.MaximumNameLength)
            //        .WithMessage(
            //        $"Customer name should have maximum {CustomerValidatorConfiguration.MaximumNameLength} characters");
        }
    }
}
