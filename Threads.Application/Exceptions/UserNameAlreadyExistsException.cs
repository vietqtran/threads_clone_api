using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Exceptions
{
    public class UserNameAlreadyExistsException : ApplicationException
    {
        public UserNameAlreadyExistsException ( ) : base($"Sorry, this username already exists.")
        {

        }
    }
}
