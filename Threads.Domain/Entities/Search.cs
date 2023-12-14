using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Domain.Entities
{
    public class Search
    {
        public Guid UserId { get; set; }
        public Guid SearchId { get; set; }

        public virtual User User { get; set; }
    }
}
