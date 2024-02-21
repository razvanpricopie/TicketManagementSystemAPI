using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Persistence.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(TicketManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Ticket>> GetTicketByOrderId(Guid orderId)
        {
            return Task.FromResult(_dbContext.Tickets.Include(t => t.Event).Where(x => x.OrderId == orderId).ToList());
        }
    }
}
