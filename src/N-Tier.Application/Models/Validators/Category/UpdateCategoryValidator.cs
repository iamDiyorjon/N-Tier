﻿using FluentValidation;
using N_Tier.Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Validators.Category
{
    public class UpdateCategoryValidator :AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Name)
           .MinimumLength(CategoryValidatorConfiguration.MinimumNameLenth)
           .WithMessage(
               $"Category name should have minimum ${CategoryValidatorConfiguration.MinimumNameLenth} characters")
           .MaximumLength(CategoryValidatorConfiguration.MaximumNameLength)
           .WithMessage(
               $"Category name should have maximum {CategoryValidatorConfiguration.MaximumNameLength} characters");
        }
    }
}
