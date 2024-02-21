using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail
{
    public class TicketDto
    {
        public Guid TicketId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
    }
}
