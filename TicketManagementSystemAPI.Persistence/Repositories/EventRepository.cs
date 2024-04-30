using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Persistence;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(TicketManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate, Guid? eventId = null)
        {
            bool matches = _dbContext.Events.Any(e => (eventId == null || !e.EventId.Equals(eventId)) && e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));

            return Task.FromResult(matches);
        }

        public async Task<IReadOnlyList<Event>> ListBySqlQueryAsync(string query)
        {
            var result = await _dbContext.Events.FromSqlRaw(query).ToListAsync();

            return result;
        }
    }
}
