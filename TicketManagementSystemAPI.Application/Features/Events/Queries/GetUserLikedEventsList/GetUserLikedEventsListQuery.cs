using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList
{
    public class GetUserLikedEventsListQuery : IRequest<List<UserLikedEventsListVm>>
    {
        public Guid UserId { get; set; }
    }
}
