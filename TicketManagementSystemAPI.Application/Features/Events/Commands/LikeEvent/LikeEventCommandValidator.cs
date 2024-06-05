using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent
{
    public class LikeEventCommandValidator : AbstractValidator<LikeEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public LikeEventCommandValidator(IEventRepository eventRepository)
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

        private async Task<bool> UserAlreadyRatedEvent(LikeEventCommand e, CancellationToken token)
        {
            return !(await _eventRepository.IsUserAlreadyRatedEvent(e.UserId, e.EventId));
        }
    }
}
