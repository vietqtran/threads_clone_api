using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Domain.Relations
{
    public class UserPollOptions
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PollOptionId { get; set; }

        public virtual User User { get; set; }
        public virtual PollOption PollOption { get; set; }
    }
}
