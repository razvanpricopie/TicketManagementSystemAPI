using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            UpdateCategoryCommanmdValidator validator = new UpdateCategoryCommanmdValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            Category categoryToUpdate = await _categoryRepository.GetByIdAsync(request.CategoryId);

            _mapper.Map(request, categoryToUpdate, typeof(UpdateEventCommand), typeof(Category));

            await _categoryRepository.UpdateAsync(categoryToUpdate);

            return Unit.Value;
        }
    }
}
