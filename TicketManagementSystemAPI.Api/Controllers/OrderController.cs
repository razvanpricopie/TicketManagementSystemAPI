using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Infrastructure;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList;
using TicketManagementSystemAPI.Application.Models.StripePayment;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IStripeService _stripeService;

        public OrderController(IMediator mediator, IStripeService stripeService)
        {
            _mediator = mediator;
            _stripeService = stripeService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderListVm>>> GetAllOrders()
        {
            List<OrderListVm> orders = await _mediator.Send(new GetOrdersListQuery());

            return Ok(orders);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{OrderId}", Name = "GetOrderDetails")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDetailVm>> GetOrderDetails(Guid orderId)
        {
            GetOrderDetailQuery getOrderDetailQuery = new GetOrderDetailQuery() { Id = orderId };

            OrderDetailVm order = await _mediator.Send(getOrderDetailQuery);

            return Ok(order);
        }

        [Authorize(Roles = "User")]
        [HttpPost("addOrder", Name = "addOrder")]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            Guid id = await _mediator.Send(createOrderCommand);

            return Ok(id);
        }

        [Authorize(Roles = "User")]
        [HttpGet("allUserOrders/{userId}", Name = "GetAllUserOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserOrderListVm>>> GetAllUserOrders(Guid userId)
        {
            GetUserOrdersListQuery getUserOrdersListQuery = new GetUserOrdersListQuery() { UserId = userId };

            List<UserOrderListVm> userOrders = await _mediator.Send(getUserOrdersListQuery);

            return Ok(userOrders);
        }


        [Authorize(Roles = "User")]
        [HttpPost("createCheckoutSession", Name = "CreateCheckoutSession")]
        public async Task<ActionResult<CheckoutOrderResponse>> CreateCheckoutSession([FromBody] CheckoutOrderRequest checkoutOrderRequest)
        {
            CheckoutOrderResponse checkoutOrderResponse = await _stripeService.CheckoutOrderResponse(checkoutOrderRequest);

            return Ok(checkoutOrderResponse);
        }

        [HttpPost("webHook", Name = "WebHook")]
        public async Task<ActionResult<CheckoutOrderResponse>> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeSignatureHeader = Request.Headers["Stripe-Signature"];

            await _stripeService.WebHook(json, stripeSignatureHeader);

            return Ok();
        }
    }
}
