using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence.Pattern;

namespace Threads.Persistence.Repositories.Pattern
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose ( )
        {
            throw new NotImplementedException();
        }

        public Task Save ( )
        {
            throw new NotImplementedException();
        }
    }
}
