using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommanmdValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommanmdValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
