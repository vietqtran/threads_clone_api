using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Relations;

namespace Threads.Domain.Entities
{
    public class Repost : BaseEntity
    {
        public Guid UserId { get; set; }
        public bool IsHide { get; set; }

        public virtual User User { get; set; }
        public virtual Reply Reply { get; set; }
        public virtual ICollection<RepostPost> RepostPosts { get; set; }
        public virtual ICollection<RepostReply> RepostReplies { get; set; }
    }
}
