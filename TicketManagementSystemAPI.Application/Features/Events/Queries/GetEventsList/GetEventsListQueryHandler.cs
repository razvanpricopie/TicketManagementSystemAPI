using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            List<Event> allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date).ToList();

            Dictionary<Guid, Category> allCategories = (await _categoryRepository.ListAllAsync()).ToDictionary(x => x.CategoryId);

            foreach (Event @event in allEvents)
            {
                if (allCategories.TryGetValue(@event.CategoryId, out Category category))
                {
                    @event.Category = allCategories[@event.CategoryId];
                }
            }

            return _mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
