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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(TicketManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetOrdersListWithTicketsAsync()
        {
            return await _dbContext.Orders.Include(x => x.Tickets).ToListAsync();
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.Orders.Where(x => x.CreatedDate.Month == date.Month && x.CreatedDate.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _dbContext.Orders.CountAsync(x => x.CreatedDate.Month == date.Month && x.CreatedDate.Year == date.Year);
        }
    }
}
