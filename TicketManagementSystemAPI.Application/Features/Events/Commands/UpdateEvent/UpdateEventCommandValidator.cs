using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(UpdateEventCommand e, CancellationToken token)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date, e.EventId));
        }
    }
}
