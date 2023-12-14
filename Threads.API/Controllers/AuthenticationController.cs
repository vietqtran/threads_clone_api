using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threads.Application.Contracts.Identity;
using Threads.Application.DTOs.User;
using Threads.Application.Features.User.Requests.Commands;
using Threads.Application.Models.Identity;
using Threads.Identity.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Threads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMediator _mediator;

        public AuthenticationController (IAuthenticationService authenticationService, IMediator mediator)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post (RegistrationRequest registerRequest)
        {
            var result = await _authenticationService.Register(registerRequest);

            if (result != null)
            {
                var createUserProfile = await _mediator.Send(new RegisterUserRequestCommand
                {
                    RegisterUserDto = new RegisterUserDto
                    {
                        UserName = registerRequest.UserName,
                        Email = registerRequest.Email,
                        Id = Guid.Parse(result.UserId),
                        Name = result.UserName
                    }
                });

                if (createUserProfile.Id == Guid.Empty)
                {
                    await _authenticationService.RevokeIdentityUser(Guid.Parse(result.UserId));
                    return BadRequest(createUserProfile.Errors);
                }
            }

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
