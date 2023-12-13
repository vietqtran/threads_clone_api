using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.DTOs.User;
using Threads.Application.Responses;

namespace Threads.Application.Features.User.Requests.Commands
{
    public class RegisterUserRequestCommand : IRequest<BaseCommandResponse>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
