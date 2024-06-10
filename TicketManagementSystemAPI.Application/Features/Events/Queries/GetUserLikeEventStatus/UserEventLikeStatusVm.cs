using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserEventRateStatus
{
    public class UserEventLikeStatusVm
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public bool? IsLiked { get; set; }
    }
}
