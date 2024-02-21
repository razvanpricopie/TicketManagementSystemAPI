using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Contracts.Persistence
{
    public interface ITicketRepository : IAsyncRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketByOrderId(Guid orderId);
    }
}
