using Microsoft.Extensions.Options;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;
using TicketManagementSystemAPI.Application.Models.OpenAI;

namespace TicketManagementSystemAPI.OpenAI.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAISettings _openAISettings;

        public OpenAIService(IOptions<OpenAISettings> openAISettings)
        {
            _openAISettings = openAISettings.Value;
        }

        public async Task<string> CompleteSentence(string text)
        {
            var api = new OpenAI_API.OpenAIAPI(_openAISettings.Key);
            var result = await api.Completions.GetCompletion(text);

            return result;
        }
    }
}
