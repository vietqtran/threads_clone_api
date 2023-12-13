using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Models.Identity;

namespace Threads.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> Register (RegistrationRequest request);
        Task<AuthenticationResponse> Login (AuthenticationRequest request);
        Task RevokeIdentityUser (Guid id);
    }
}
