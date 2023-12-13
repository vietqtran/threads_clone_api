using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threads.Application.DTOs.User;
using Threads.Application.Features.User.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Threads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get ( )
        {
            var result = await _mediator.Send(new GetAllUserRequestQuery());
            return Ok(result);
        }

    }
}
