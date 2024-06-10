using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.DislikeEvent
{
    public class DislikeEventCommandHandler : IRequestHandler<DislikeEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public DislikeEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DislikeEventCommand request, CancellationToken cancellationToken)
        {
            DislikeEventCommandValidator validator = new DislikeEventCommandValidator(_eventRepository);
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            EventLikeStatus like = _mapper.Map<EventLikeStatus>(request);
            like.IsLiked = false;

            await _eventRepository.CreateUserLikeEventStatus(like);

            return Unit.Value;
        }
    }
}
