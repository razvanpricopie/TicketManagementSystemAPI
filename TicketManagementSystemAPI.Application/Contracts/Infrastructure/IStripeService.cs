using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Models.StripePayment;

namespace TicketManagementSystemAPI.Application.Contracts.Infrastructure
{
    public interface IStripeService
    {
        Task<CheckoutOrderResponse> CheckoutOrderResponse(CheckoutOrderRequest checkoutOrderRequest);
        Task WebHook(string json, string stripeSignatureHeader);
    }
}
