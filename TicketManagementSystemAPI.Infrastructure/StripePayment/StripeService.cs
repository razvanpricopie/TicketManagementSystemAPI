using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;
using Stripe.Forwarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Infrastructure;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Application.Models.StripePayment;
using TicketManagementSystemAPI.Domain.Entities;
using TicketManagementSystemAPI.Infrastructure.StripePayment.Validations;
using static System.Formats.Asn1.AsnWriter;

namespace TicketManagementSystemAPI.Infrastructure.StripePayment
{
    public class StripeService : IStripeService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IAsyncRepository<Domain.Entities.Order> _orderRepository;
        private readonly IMapper _mapper;

        public StripeService(IOptions<StripeSettings> stripeSettings, IAsyncRepository<Domain.Entities.Order> orderRepository, IMapper mapper)
        {
            _stripeSettings = stripeSettings.Value;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CheckoutOrderResponse> CheckoutOrderResponse(CheckoutOrderRequest checkoutOrderRequest)
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl = checkoutOrderRequest.SuccessUrl,
                CancelUrl = checkoutOrderRequest.FailureUrl,
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                Mode = "payment",
                Metadata = new Dictionary<string, string>
                {
                    { "UserId", checkoutOrderRequest.UserId.ToString() },
                    {"OrderTotal", checkoutOrderRequest.OrderTotal.ToString() },
                    { "ticketDetails", JsonConvert.SerializeObject(checkoutOrderRequest.Tickets) }
                },
            };

            options.LineItems = CreateLineItemProductDataOptions(checkoutOrderRequest.Tickets.ToList());

            var service = new SessionService();

            service.Create(options);
            var session = await service.CreateAsync(options);

            try
            {

                return new CheckoutOrderResponse
                {
                    SessionId = session.Id,
                    PubKey = _stripeSettings.PubKey
                };
            }
            catch (StripeException ex)
            {
                throw new BadRequestException(ex.StripeError.Message);
            }
        }

        public async Task WebHook(string json, string stripeSignatureHeader)
        {
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, stripeSignatureHeader, _stripeSettings.WebhookSecret);

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;

                    List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(session.Metadata["ticketDetails"]);

                    Domain.Entities.Order order = new Domain.Entities.Order
                    {
                        UserId = Guid.Parse(session.Metadata["UserId"]),
                        OrderTotal = int.Parse(session.Metadata["OrderTotal"]),
                        Tickets = _mapper.Map<List<Ticket>>(tickets)
                    };

                    CreateOrderValidator validator = new CreateOrderValidator();
                    ValidationResult validationResult = await validator.ValidateAsync(order);

                    if (validationResult.Errors.Count > 0)
                        throw new Application.Exceptions.ValidationException(validationResult);

                    await _orderRepository.AddAsync(order);
                }
                else
                {
                    return;
                }
            }
            catch (StripeException ex)
            {
                throw new BadRequestException(ex.StripeError.Message);
            }

        }

        private List<SessionLineItemOptions> CreateLineItemProductDataOptions(List<TicketDto> tickets)
        {
            return tickets.Select(ticket => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "eur",
                    UnitAmount = ticket.Price * 100,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ticket.EventName,
                    },
                },
                Quantity = ticket.Quantity,
            }).ToList();
        }
    }
}
