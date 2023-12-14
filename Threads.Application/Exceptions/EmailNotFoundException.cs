﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Application.Exceptions
{
    public class EmailNotFoundException : ApplicationException
    {
        public EmailNotFoundException ( ) : base($"Sorry, this email does not exist.")
        {

        }
    }
}
