using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Identity;
using TicketManagementSystemAPI.Application.Models.Authentication;

namespace TicketManagementSystemAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("UpdateUser/{UserId}", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUserAsync(UpdateUserRequest request)
        {
            await _authenticationService.UpdateUserAsync(request);

            return NoContent();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("UpdatePassword/{UserId}", Name = "UpdatePassword")]
        public async Task<ActionResult> UpdatePasswordAsync(UpdatePasswordRequest request)
        {
            await _authenticationService.UpdatePasswordAsync(request);

            return NoContent();
        }
    }
}
