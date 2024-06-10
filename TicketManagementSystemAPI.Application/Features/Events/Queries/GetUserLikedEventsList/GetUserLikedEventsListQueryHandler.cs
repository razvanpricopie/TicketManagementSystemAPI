using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList
{
    public class GetUserLikedEventsListQueryHandler : IRequestHandler<GetUserLikedEventsListQuery, List<UserLikedEventsListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetUserLikedEventsListQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<List<UserLikedEventsListVm>> Handle(GetUserLikedEventsListQuery request, CancellationToken cancellationToken)
        {
            List<Event> userLikedEvents = (await _eventRepository.GetUserFavouriteEventsByLikeStatus(request.UserId, true)).ToList();

            return _mapper.Map<List<UserLikedEventsListVm>>(userLikedEvents);
        }
    }
}
