using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.DislikeEvent
{
    public class DislikeEventCommandValidator : AbstractValidator<DislikeEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DislikeEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.EventId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(UserAlreadyRatedEvent)
                .WithMessage("User already rated this event.");
        }

        private async Task<bool> UserAlreadyRatedEvent(DislikeEventCommand e, CancellationToken token)
        {
            return !(await _eventRepository.IsUserAlreadyRatedEvent(e.UserId, e.EventId));
        }
    }
}
