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

        public async Task<EventLikeStatus> GetUserLikeEventStatusByUserAndEventIds(Guid userId, Guid eventId)
        {
            return await _dbContext.EventsLikeStatuses.FirstOrDefaultAsync(l => l.UserId == userId && l.EventId == eventId);
        }

        public async Task<EventLikeStatus> GetUserLikeEventStatusById(Guid id)
        {
            return await _dbContext.EventsLikeStatuses.FindAsync(id);
        }

        public async Task CreateUserLikeEventStatus(EventLikeStatus like)
        {
            await _dbContext.EventsLikeStatuses.AddAsync(like);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserLikeEventStatus(EventLikeStatus like)
        {
            _dbContext.EventsLikeStatuses.Remove(like);

            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> IsUserAlreadyRatedEvent(Guid userId, Guid eventId)
        {
            bool isAlreadyLiked = _dbContext.EventsLikeStatuses.Any(l => l.EventId == eventId && l.UserId == userId);

            return Task.FromResult(isAlreadyLiked);
        }

        public async Task<IReadOnlyList<Event>> GetUserFavouriteEventsByLikeStatus(Guid userId, bool isLiked)
        {
            var userFavouriteEvents = await _dbContext.Events.Where(e => e.Likes.Any(l => l.UserId == userId && l.IsLiked == isLiked)).ToListAsync();

            return userFavouriteEvents;
        }
    }
}
