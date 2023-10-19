using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Exceptions;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            if (eventToUpdate == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            UpdateEventCommandValidator validator = new UpdateEventCommandValidator(_eventRepository);
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}