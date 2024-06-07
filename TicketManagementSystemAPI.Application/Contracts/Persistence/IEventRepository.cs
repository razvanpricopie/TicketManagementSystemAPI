using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate, Guid? eventId = null);
        Task<IReadOnlyList<Event>> GetUserFavouriteEventsByLikeStatus(Guid userId, bool isLiked);
        Task<EventLikeStatus> GetUserLikeEventStatusByUserAndEventIds(Guid userId, Guid eventId);
        Task<EventLikeStatus> GetUserLikeEventStatusById(Guid id);
        Task CreateUserLikeEventStatus(EventLikeStatus like);
        Task DeleteUserLikeEventStatus(EventLikeStatus like);
        Task<bool> IsUserAlreadyRatedEvent(Guid userId, Guid eventId);
    }
}
