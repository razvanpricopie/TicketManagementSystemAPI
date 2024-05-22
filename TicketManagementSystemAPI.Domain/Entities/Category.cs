using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Domain.Common;

namespace TicketManagementSystemAPI.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
