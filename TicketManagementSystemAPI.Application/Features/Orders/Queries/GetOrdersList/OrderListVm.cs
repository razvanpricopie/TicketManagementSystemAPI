using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrderListVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
