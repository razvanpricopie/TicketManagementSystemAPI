using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList
{
    public class TicketDto
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Guid EventId { get; set; }
        public EventDto Event { get; set; }
    }
}
