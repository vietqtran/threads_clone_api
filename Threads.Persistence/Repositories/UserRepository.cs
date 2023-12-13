using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;
using Threads.Domain.Entities;
using Threads.Persistence.Repositories.Generic;

namespace Threads.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public UserRepository (ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<bool> IsValidUser (Guid id, string email, string userName)
        {
            var result = await _applicationDBContext.Users
                .Where(x => x.Id == id || x.Email == email || x.UserName == userName).FirstOrDefaultAsync();

            return result == null;
        }
    }
}
