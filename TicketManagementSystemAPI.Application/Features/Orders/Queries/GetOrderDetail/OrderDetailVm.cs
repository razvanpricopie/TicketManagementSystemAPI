using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail
{
    public class OrderDetailVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
