using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Domain.Enums
{
    public enum NotificationType
    {
        Follows = 1,
        Replies = 2,
        Mentions = 3,
        Quotes = 4,
        Reposts = 5,
        Verified = 6,
    }
}
