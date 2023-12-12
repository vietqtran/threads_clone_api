using Microsoft.AspNetCore.Mvc;
using Threads.Application.Contracts.Identity;
using Threads.Application.Models.Identity;
using Threads.Identity.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Threads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public ApplicationUserController (IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post (RegistrationRequest registerRequest)
        {
            var result = await _authenticationService.Register(registerRequest);
            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post (AuthenticationRequest authenticationRequest)
        {
            var result = await _authenticationService.Login(authenticationRequest);
            return Ok(result);
        }
    }
}
