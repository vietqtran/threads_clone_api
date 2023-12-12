using System;
using System.Threading.Tasks;

namespace Threads.Application.Contracts.Persistence.Pattern
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save ( );
    }
}
