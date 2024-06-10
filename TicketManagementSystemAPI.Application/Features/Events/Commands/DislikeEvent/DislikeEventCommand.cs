using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.DislikeEvent
{
    public class DislikeEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}
