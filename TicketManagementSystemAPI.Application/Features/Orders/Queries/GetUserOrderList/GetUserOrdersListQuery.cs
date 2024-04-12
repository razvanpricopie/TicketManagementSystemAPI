using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList
{
    public class GetUserOrdersListQuery : IRequest<List<UserOrderListVm>>
    {
        public Guid UserId { get; set; }
    }
}
