using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.OpenAI.Services;

namespace TicketManagementSystemAPI.OpenAI
{
    public static class OpenAIServiceExtensions
    {
        public static void AddOpenAIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenAISettings>(configuration.GetSection("OpenAISettings"));

            services.AddTransient<IOpenAIService, OpenAIService>();
        }
    }
}
