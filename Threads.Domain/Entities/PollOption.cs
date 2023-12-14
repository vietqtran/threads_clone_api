using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Relations;

namespace Threads.Domain.Entities
{
    public class PollOption : BaseEntity
    {
        public long VoteCount { get; set; }
        public string Option { get; set; }
        public Guid PollId { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual ICollection<UserPollOptions> UserPollOptions { get; set; }
    }
}
