using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;

namespace Threads.Domain.Entities
{
    public class Media : BaseEntity
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string Alt { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ReplyId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Reply Reply { get; set; }
    }
}
