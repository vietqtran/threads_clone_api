using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;
using Threads.Application.Contracts.Persistence.Pattern;

namespace Threads.Persistence.Repositories.Pattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _applicationDBContext;

        private IUserRepository _userRepository;

        public UnitOfWork (ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_applicationDBContext);

        public void Dispose ( )
        {
            _applicationDBContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save ( )
        {
            await _applicationDBContext.SaveChangesAsync();
        }
    }
}
