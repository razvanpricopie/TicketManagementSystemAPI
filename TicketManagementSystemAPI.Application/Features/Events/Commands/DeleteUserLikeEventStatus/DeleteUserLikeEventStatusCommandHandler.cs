using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Exceptions;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.UnrateEvent
{
    public class DeleteUserLikeEventStatusCommandHandler : IRequestHandler<DeleteUserLikeEventStatusCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public DeleteUserLikeEventStatusCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteUserLikeEventStatusCommand request, CancellationToken cancellationToken)
        {
            EventLikeStatus likeStatusToDelete = await _eventRepository.GetUserLikeEventStatusById(request.Id);

            if (likeStatusToDelete == null)
                throw new NotFoundException($"There is not any record with Id: {request.Id}");

            await _eventRepository.DeleteUserLikeEventStatus(likeStatusToDelete);

            return Unit.Value;
        }
    }
}
