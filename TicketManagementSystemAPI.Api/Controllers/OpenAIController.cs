using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;
using TicketManagementSystemAPI.Application.Models.OpenAI;
using TicketManagementSystemAPI.Domain.Entities;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAIController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost("mostTenBoughtEvents", Name = "GetMostTenBoughtEvents")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetMostTenBoughtEvents()
        {
            List<OpenAIEventListResponse> events = await _openAIService.GetMostTenBoughtEvents();

            return Ok(events);
        }

        [HttpPost("lastTenAddedEvents", Name = "GetLastTenAddedEvents")]
        public async Task<ActionResult<List<OpenAIEventListResponse>>> GetLastTenAddedEvents()
        {
            List<OpenAIEventListResponse> events = await _openAIService.GetLastTenAddedEvents();

            return Ok(events);
        }
    }
}
