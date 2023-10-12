using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p)
                .MustAsync(CategoryNameUniqueAsync)
                .WithMessage("A category with the same name already exists..");
        }

        private async Task<bool> CategoryNameUniqueAsync(CreateCategoryCommand c, CancellationToken cancellationToken)
        {
            return !(await _categoryRepository.IsCategoryNameUnique(c.Name));
        }
    }
}
