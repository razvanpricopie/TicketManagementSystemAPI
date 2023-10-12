using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEventsAsync(bool includePassedEvents);
        Task<bool> IsCategoryNameUnique(string name);
    }
}
