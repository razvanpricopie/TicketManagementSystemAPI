using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Models.StripePayment
{
    public class StripeSettings
    {
        public string PubKey { get; set; }
        public string WebhookSecret { get; set; }
    }
}
