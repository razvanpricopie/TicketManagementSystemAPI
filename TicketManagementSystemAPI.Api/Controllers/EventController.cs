using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Features.Events.Commands.CreateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.DeleteEvent;
using TicketManagementSystemAPI.Application.Features.Events.Commands.UpdateEvent;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList;

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
        public async Task<ActionResult<Guid>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            Guid id = await _mediator.Send(createEventCommand);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{EventId}", Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEvent(UpdateEventCommand updateEventCommand)
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
    }
}
