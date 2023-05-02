using FluentValidation.Results;
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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TicketManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEventsAsync(bool includePassedEvents)
        {
            List<Category> allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            if(!includePassedEvents)
            {
                allCategories.ForEach(p=>p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return allCategories;
        }
    }
}
