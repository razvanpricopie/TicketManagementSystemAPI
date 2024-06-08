using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Models.StripePayment
{
    public class CheckoutOrderRequest
    {
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
    }

    public class TicketDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
