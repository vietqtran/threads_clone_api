using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Enums;

namespace Threads.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ReplyId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Reply Reply { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
    }
}
