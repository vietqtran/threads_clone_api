using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.DTOs.Common;

namespace Threads.Application.DTOs.User
{
    public class RegisterUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
