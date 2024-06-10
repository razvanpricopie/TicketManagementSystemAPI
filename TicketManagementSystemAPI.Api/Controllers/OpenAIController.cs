using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList;
using TicketManagementSystemAPI.Application.Features.Orders.Queries.GetUserOrderList;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;
        private readonly IMediator _mediator;

        public OpenAIController(IOpenAIService openAIService, IMediator mediator)
        {
            _openAIService = openAIService;
            _mediator = mediator;
        }

        [HttpPost("mostTenBoughtEvents", Name = "GetMostTenBoughtEvents")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetMostTenBoughtEvents()
        {
            List<OpenAIEventListResponse> events = await _openAIService.GetMostTenBoughtEvents();

            return Ok(events);
        }

        [HttpPost("lastTenAddedEvents", Name = "GetLastTenAddedEvents")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetLastTenAddedEvents()
        {
            List<OpenAIEventListResponse> events = await _openAIService.GetLastTenAddedEvents();

            return Ok(events);
        }

        [HttpPost("tenEventsBasedOnUserOrders/{userId}", Name = "GetTenEventsBasedOnUserOrders")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetTenEventsBasedOnUserOrders(Guid userId)
        {
            GetUserOrdersListQuery getUserOrdersListQuery = new GetUserOrdersListQuery() { UserId = userId };
            List<UserOrderListVm> userOrders = await _mediator.Send(getUserOrdersListQuery);

            if (userOrders.Count == 0)
            {
                return Ok();
            }

            List<OpenAIEventListResponse> events = await _openAIService.GetTenEventsBasedOnUserOrders(userId);

            return Ok(events);
        }

        [HttpPost("getTenEventsBasedOnUserLikeStatuses/{userId}", Name = "GetTenEventsBasedOnUserLikeStatuses")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetTenEventsBasedOnUserLikeStatuses(Guid userId)
        {
            GetUserLikedEventsListQuery getUserLikedEventsListQuery = new GetUserLikedEventsListQuery() { UserId = userId };

            List<UserLikedEventsListVm> likedEvents = await _mediator.Send(getUserLikedEventsListQuery);

            if (likedEvents.Count == 0)
            {
                return Ok();
            }

            List<OpenAIEventListResponse> events = await _openAIService.GetTenEventsBasedOnUserLikeStatuses(userId);

            return Ok(events);
        }

        [HttpPost("getTenEventsBasedOnOtherUsersLikeStatuses/{userId}", Name = "GetTenEventsBasedOnOtherUsersLikeStatuses")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetTenEventsBasedOnOtherUsersLikeStatuses(Guid userId)
        {
            List<OpenAIEventListResponse> events = await _openAIService.GetTenEventsBasedOnOtherUsersLikeStatuses(userId);

            return Ok(events);
        }
    }
}
