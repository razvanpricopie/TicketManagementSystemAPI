using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.OpenAI;

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

        [HttpPost("completeSentence", Name = "CompleteSentence")]
        public async Task<ActionResult> CompleteSentence([FromBody] string text)
        {
            string result = await _openAIService.CompleteSentence(text);

            return Ok(result);
        }
    }
}
