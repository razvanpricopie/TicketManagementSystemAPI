using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder
{
    public class TicketDto
    {
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
