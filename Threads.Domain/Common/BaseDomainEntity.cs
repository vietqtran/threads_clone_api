using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public Guid Id { get; set; }
    }
}
