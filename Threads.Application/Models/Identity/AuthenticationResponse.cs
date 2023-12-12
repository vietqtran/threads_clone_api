using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
