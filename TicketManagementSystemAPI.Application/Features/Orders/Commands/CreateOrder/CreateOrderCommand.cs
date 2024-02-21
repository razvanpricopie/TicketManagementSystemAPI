using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
    }
}
