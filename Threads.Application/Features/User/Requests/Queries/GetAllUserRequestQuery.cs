using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.DTOs.User;

namespace Threads.Application.Features.User.Requests.Queries
{
    public class GetAllUserRequestQuery : IRequest<List<UserDto>>
    {
    }
}
