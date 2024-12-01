using FluentValidation;
using N_Tier.Application.Models.CustomerModels;
using N_Tier.Application.Models.Validators.Product;

namespace N_Tier.Application.Models.Validators.Customer
{
    public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerModelValidator()
        {
            //RuleFor(c=>c.PersonId).NotEmpty()
            //    .MinimumLength(CustomerValidatorConfiguration.MinimumNameLenth)
            //    .WithMessage($"Customer name should have minimum ${ProductValidatorConfiguration.MinimumNameLenth} characters")
            //    .MaximumLength(CustomerValidatorConfiguration.MaximumNameLength)
            //    .WithMessage(
            //        $"Customer name should have maximum {CustomerValidatorConfiguration.MaximumNameLength} characters");
        }
    }
}
