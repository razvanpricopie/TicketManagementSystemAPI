using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(Guid id);
        Task<T> UpdateAsync(Guid id);
        Task<T> DeleteAsync(Guid id);
    }
}
