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
        public DateTime Date { get; set; }
        public bool OrderPaid { get; set; }

        public override string ToString()
        {
            return $"Order user: {UserId}; Order total: {OrderTotal}; Order paid: {OrderPaid}; On: {Date.ToShortDateString()}";
        }
    }
}
