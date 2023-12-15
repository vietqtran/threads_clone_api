using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Domain.Relations
{
    public class Like
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ReplyId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Reply Reply { get; set; }
    }
}
