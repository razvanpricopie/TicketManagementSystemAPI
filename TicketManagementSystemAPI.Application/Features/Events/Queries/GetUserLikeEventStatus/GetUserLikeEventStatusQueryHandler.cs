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

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserEventRateStatus
{
    public class GetUserLikeEventStatusQueryHandler : IRequestHandler<GetUserLikeEventStatusQuery, UserEventLikeStatusVm>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetUserLikeEventStatusQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<UserEventLikeStatusVm> Handle(GetUserLikeEventStatusQuery request, CancellationToken cancellationToken)
        {
            EventLikeStatus like = await _eventRepository.GetUserLikeEventStatusByUserAndEventIds(request.UserId, request.EventId);

            if (like == null)
                return null;

            UserEventLikeStatusVm userEventLikeStatusVm = _mapper.Map<UserEventLikeStatusVm>(like);

            return userEventLikeStatusVm;
        }
    }
}
