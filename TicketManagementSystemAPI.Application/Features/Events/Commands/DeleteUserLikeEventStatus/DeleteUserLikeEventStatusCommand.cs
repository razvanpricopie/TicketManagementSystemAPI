using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Features.Events.Commands.UnrateEvent
{
    public class DeleteUserLikeEventStatusCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
