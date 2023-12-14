using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities.Common;
using Threads.Domain.Enums;

namespace Threads.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public NotificationType Type { get; set; }
        public string Content { get; set; }

        public virtual User User { get; set; }
    }
}
