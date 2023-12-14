using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;

namespace Threads.Domain.Entities
{
    public class Poll : BaseEntity
    {
        public string Question { get; set; }
        public Guid? QuoteId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ReplyId { get; set; }

        public virtual Quote Quote { get; set; }
        public virtual Post Post { get; set; }
        public virtual Reply Reply { get; set; }
        public virtual ICollection<PollOption> PollOptions { get; set; }
    }
}
