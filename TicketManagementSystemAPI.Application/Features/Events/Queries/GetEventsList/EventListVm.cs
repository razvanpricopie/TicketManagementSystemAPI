using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventDetail;

namespace TicketManagementSystemAPI.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Artist { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
