using System;
using System.Collections.Generic;
using System.Text;
using TicketManagementSystemAPI.Domain.Common;

namespace TicketManagementSystemAPI.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime Date { get; set; }
        public bool OrderPaid { get; set; }
    }
}
