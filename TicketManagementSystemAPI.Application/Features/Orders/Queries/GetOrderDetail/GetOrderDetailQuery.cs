using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;

namespace TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public Guid Id { get; set; }
    }
}
