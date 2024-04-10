using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Orders.Commands.CreateOrder;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrderDetail;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetOrdersList;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
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

        [Authorize(Roles = "Admin, User")]
        [HttpPost("addOrder", Name = "addOrder")]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            Guid id = await _mediator.Send(createOrderCommand);

            return Ok(id);
        }
    }
}
