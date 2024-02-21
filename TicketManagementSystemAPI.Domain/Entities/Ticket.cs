using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
