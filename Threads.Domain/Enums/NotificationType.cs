﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Domain.Enums
{
    public enum NotificationType
    {
        FOLLOWS = 1,
        REPLIES = 2,
        MENTIONS = 3,
        QUOTES = 4,
        REPOSTS = 5,
        VERIFIED = 6,
    }
}
