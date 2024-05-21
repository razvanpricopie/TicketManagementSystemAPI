using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Application.Contracts.OpenAI
{
    public interface IOpenAIService
    {
        Task<List<OpenAIEventListResponse>> GetMostTenBoughtEvents();
        Task<List<OpenAIEventListResponse>> GetLastTenAddedEvents();
        Task<List<OpenAIEventListResponse>> GetTenEventsBasedOnUserOrders(Guid userId);
    }
}
