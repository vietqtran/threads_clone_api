using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.DTOs.Common;

namespace Threads.Application.DTOs.User
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
