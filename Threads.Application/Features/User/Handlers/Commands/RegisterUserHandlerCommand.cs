using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;
using Threads.Application.Contracts.Persistence.Pattern;
using Threads.Application.DTOs.User.Validatiors;
using Threads.Application.Features.User.Requests.Commands;
using Threads.Application.Responses;

namespace Threads.Application.Features.User.Handlers.Commands
{
    public class RegisterUserHandlerCommand : IRequestHandler<RegisterUserRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandlerCommand (IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle (RegisterUserRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new RegisterUserDtoValidator(_unitOfWork.UserRepository);
            var validationResult = await validator.ValidateAsync(request.RegisterUserDto);

            if (!validationResult.IsValid)
            {
                response.Id = Guid.Empty;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
                response.Message = "User registration failed.";
            }
            else
            {
                var user = _mapper.Map<Domain.Entities.User>(request.RegisterUserDto);
                var result = await _unitOfWork.UserRepository.Add(user);

                if (result == null)
                {
                    response.Id = Guid.Empty;
                    response.Errors.Add("User registration failed.");
                    response.Success = false;
                    response.Message = "User registration failed.";
                }
                else
                {
                    await _unitOfWork.Save();
                    response.Id = request.RegisterUserDto.Id;
                    response.Success = true;
                    response.Message = "User registration successful.";
                }
            }

            return response;
        }
    }
}
