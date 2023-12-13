using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;

namespace Threads.Application.DTOs.User.Validatiors
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserDtoValidator (IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x)
                .MustAsync(async (x, cancellation) => (await _userRepository.IsValidUser(x.Id, x.Email, x.UserName)))
                .WithMessage("Email already exists.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("{FieldName} length must be less than {Length} characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30).WithMessage("{FieldName} length must be less than {Length} characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MaximumLength(50).WithMessage("{FieldName} length must be less than {Length} characters.");
        }
    }
}
