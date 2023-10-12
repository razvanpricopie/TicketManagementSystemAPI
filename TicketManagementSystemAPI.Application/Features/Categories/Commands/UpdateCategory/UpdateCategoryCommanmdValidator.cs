using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Categories.Commands.CreateCategory;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommanmdValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommanmdValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p)
                .MustAsync(CategoryNameUniqueAsync)
                .WithMessage("A category with the same name already exists..");

            //RuleFor(p => p)
            //    .MustAsync(CategoryExists)
            //    .WithMessage("You update nothing :( This category not even exists");
        }

        private async Task<bool> CategoryNameUniqueAsync(UpdateCategoryCommand c, CancellationToken cancellationToken)
        {
            return !(await _categoryRepository.IsCategoryNameUnique(c.Name));
        }

        ///////////GOT AN ERROR HERE, PLS FIX IT
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task<bool> CategoryExists(UpdateCategoryCommand c, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(c.CategoryId);

            if (category != null)
                return true;

            return false;
        }
    }
}
