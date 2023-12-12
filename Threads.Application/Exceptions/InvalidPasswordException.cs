using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Exceptions
{
    public class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException (string password) : base($"Sorry, your password was incorrect. Please double-check your password.")
        {

        }
    }
}
