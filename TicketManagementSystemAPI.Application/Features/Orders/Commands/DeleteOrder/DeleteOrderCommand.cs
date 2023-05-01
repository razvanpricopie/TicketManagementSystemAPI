using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
