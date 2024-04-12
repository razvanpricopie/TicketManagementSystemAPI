using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
    }
}
