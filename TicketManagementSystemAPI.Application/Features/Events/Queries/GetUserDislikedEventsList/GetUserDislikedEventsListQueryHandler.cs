using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserDislikedEventsList
{
    public class GetUserDislikedEventsListQueryHandler : IRequestHandler<GetUserDislikedEventsListQuery, List<UserDislikedEventsListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetUserDislikedEventsListQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<List<UserDislikedEventsListVm>> Handle(GetUserDislikedEventsListQuery request, CancellationToken cancellationToken)
        {
            List<Event> userDislikedEvents = (await _eventRepository.GetUserFavouriteEventsByLikeStatus(request.UserId, false)).ToList();

            return _mapper.Map<List<UserDislikedEventsListVm>>(userDislikedEvents);
        }
    }
}
