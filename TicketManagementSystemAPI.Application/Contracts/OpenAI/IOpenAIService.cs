using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemAPI.Application.Contracts.OpenAI
{
    public interface IOpenAIService
    {
        Task<string> CompleteSentence(string text);
    }
}
