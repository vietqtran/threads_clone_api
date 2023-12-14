using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Domain.Relations
{
    public class UserBlock
    {
        public Guid BlockerId { get; set; }
        public Guid BlockedId { get; set; }

        public virtual User Blocker { get; set; }
        public virtual User Blocked { get; set; }
    }
}
