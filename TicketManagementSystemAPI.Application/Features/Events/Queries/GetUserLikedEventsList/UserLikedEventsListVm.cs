using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList
{
    public class UserLikedEventsListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Artist { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
