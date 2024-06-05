using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Domain.Entities
{
    public class EventLikeStatus
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public bool IsLiked { get; set; } //True for like, False for dislike - neutral state is translated by missing record
    }
}
