using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Exceptions
{
    public class SomethingWentWrongException : ApplicationException
    {
        public SomethingWentWrongException ( ) : base($"Something went wrong!")
        {

        }
    }
}
