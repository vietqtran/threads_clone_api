using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Domain.Relations
{
    public class RepostReply
    {
        public int Id { get; set; }
        public Guid RepostId { get; set; }
        public Guid ReplyId { get; set; }

        public virtual Repost Repost { get; set; }
        public virtual Reply Reply { get; set; }
    }
}
