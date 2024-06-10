using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserDislikedEventsList
{
    public class GetUserDislikedEventsListQuery : IRequest<List<UserDislikedEventsListVm>>
    {
        public Guid UserId { get; set; }
    }
}
