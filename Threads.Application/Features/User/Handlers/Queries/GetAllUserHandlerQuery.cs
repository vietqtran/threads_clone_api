using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;
using Threads.Application.Contracts.Persistence.Pattern;
using Threads.Application.DTOs.User;
using Threads.Application.Features.User.Requests.Queries;

namespace Threads.Application.Features.User.Handlers.Queries
{
    public class GetAllUserHandlerQuery : IRequestHandler<GetAllUserRequestQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserHandlerQuery (IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle (GetAllUserRequestQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userRepository.GetAll();

            var result = _mapper.Map<List<UserDto>>(allUsers);

            return result;
        }
    }
}
