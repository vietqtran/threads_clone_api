using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence.Generic;
using Threads.Domain.Entities;

namespace Threads.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsValidUser (Guid id, string email, string userName);
    }
}
