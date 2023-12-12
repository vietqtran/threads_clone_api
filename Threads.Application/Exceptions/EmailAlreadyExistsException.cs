using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Exceptions
{
    public class EmailAlreadyExistsException : ApplicationException
    {
        public EmailAlreadyExistsException (string email) : base($"Sorry, this email already exists.")
        {

        }
    }
}
