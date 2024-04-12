using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList
{
    public class UserOrderListVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
