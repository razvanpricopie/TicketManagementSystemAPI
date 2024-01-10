using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Categories.Queries.GetCategoryWithEvents
{
    public class GetCategoryWithEventsQuery : IRequest<CategoryWithEventsVm>
    {
        public Guid Id { get; set; }
        public bool IncludeHistory { get; set; }
    }
}
