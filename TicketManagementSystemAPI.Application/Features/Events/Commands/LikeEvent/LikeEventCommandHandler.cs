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
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent
{
    public class LikeEventCommandHandler : IRequestHandler<LikeEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public LikeEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(LikeEventCommand request, CancellationToken cancellationToken)
        {
            LikeEventCommandValidator validator = new LikeEventCommandValidator(_eventRepository);
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            EventLikeStatus like = _mapper.Map<EventLikeStatus>(request);
            like.IsLiked = true;

            await _eventRepository.CreateUserLikeEventStatus(like);

            return Unit.Value;
        }
    }
}
