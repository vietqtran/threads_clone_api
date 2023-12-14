using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Domain.Enums
{
    public enum ReplyAudience
    {
        ANYONE = 1,
        FOLLOWERS = 2,
        FOLLOWING = 3,
        MENTIONED = 4
    }
}
