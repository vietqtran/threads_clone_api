using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Domain.Relations
{
    public class UserFollow
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }

        public virtual User Follower { get; set; }
        public virtual User Followed { get; set; }
    }
}
