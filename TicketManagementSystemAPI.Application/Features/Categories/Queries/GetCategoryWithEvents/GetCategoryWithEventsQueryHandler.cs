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

namespace TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoryWithEvents
{
    public class GetCategoryWithEventsQueryHandler : IRequestHandler<GetCategoryWithEventsQuery, CategoryWithEventsVm>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryWithEventsVm> Handle(GetCategoryWithEventsQuery request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetCategoryWithEventsAsync(request.Id, request.IncludeHistory);

            return _mapper.Map<CategoryWithEventsVm>(category);
        }
    }
}
