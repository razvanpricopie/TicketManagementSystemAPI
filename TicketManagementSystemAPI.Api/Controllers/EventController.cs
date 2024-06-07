using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DeleteEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DislikeEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.LikeEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UnrateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserDislikedEventsList;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserEventRateStatus;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetUserFavouriteEventsList;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allevents", Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            List<EventListVm> events = await _mediator.Send(new GetEventsListQuery());
            return Ok(events);
        }

        [HttpGet("{EventId}", Name = "GetEventDetails")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventDetailVm>> GetEventDetails(Guid eventId)
        {
            GetEventDetailQuery getEventDetailQuery = new GetEventDetailQuery() { Id = eventId };

            EventDetailVm @event = await _mediator.Send(getEventDetailQuery);

            return Ok(@event);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addEvent", Name = "AddEvent")]
        public async Task<ActionResult<Guid>> CreateEvent([FromForm] CreateEventCommand createEventCommand)
        {
            Guid id = await _mediator.Send(createEventCommand);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{EventId}", Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEvent([FromForm] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{EventId}", Name = "DeleteEvent")]
        public async Task<ActionResult> DeleteEvent(Guid eventId)
        {
            DeleteEventCommand deleteEventCommand = new DeleteEventCommand() { EventId = eventId };

            await _mediator.Send(deleteEventCommand);

            return NoContent();
        }

        [HttpGet("getUserLikeEventStatus", Name = "GetUserLikeEventStatus")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserEventLikeStatusVm>> GetUserLikeEventStatus([FromQuery] Guid userId, [FromQuery] Guid eventId)
        {
            GetUserLikeEventStatusQuery getUserLikeEventStatusQuery = new GetUserLikeEventStatusQuery()
            {
                UserId = userId,
                EventId = eventId
            };

            UserEventLikeStatusVm like = await _mediator.Send(getUserLikeEventStatusQuery);

            if (like == null)
                return Ok(new UserEventLikeStatusVm() { UserId = userId, EventId = eventId, IsLiked = null });

            return Ok(like);
        }

        [HttpPost("likeEvent", Name = "LikeEvent")]
        public async Task<ActionResult> LikeEvent([FromBody] LikeEventCommand likeEventCommand)
        {
            await _mediator.Send(likeEventCommand);

            return Ok();
        }

        [HttpPost("dislikeEvent", Name = "DislikeEvent")]
        public async Task<ActionResult> DislikeEvent([FromBody] DislikeEventCommand dislikeEventCommand)
        {
            await _mediator.Send(dislikeEventCommand);

            return Ok();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("deleteUserLikeEventStatus/{Id}", Name = "DeleteUserLikeEventStatus")]
        public async Task<ActionResult> DeleteUserLikeEventStatus(Guid id)
        {
            DeleteUserLikeEventStatusCommand deleteEventCommand = new DeleteUserLikeEventStatusCommand()
            {
                Id = id
            };

            await _mediator.Send(deleteEventCommand);

            return NoContent();
        }

        [HttpGet("getUserLikedEvents/{UserId}", Name = "GetUserLikedEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserLikedEventsListVm>>> GetUserLikedEvents(Guid userId)
        {
            GetUserLikedEventsListQuery getUserLikedEventsListQuery = new GetUserLikedEventsListQuery() { UserId = userId };

            List<UserLikedEventsListVm> events = await _mediator.Send(getUserLikedEventsListQuery);

            return Ok(events);
        }

        [HttpGet("getUserDislikedEvents/{UserId}", Name = "GetUserDislikedEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDislikedEventsListVm>>> GetUserDislikedEvents(Guid userId)
        {
            GetUserDislikedEventsListQuery getUserDislikedEventsListQuery = new GetUserDislikedEventsListQuery() { UserId = userId };

            List<UserDislikedEventsListVm> events = await _mediator.Send(getUserDislikedEventsListQuery);

            return Ok(events);
        }
    }
}
