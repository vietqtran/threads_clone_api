using System;
using System.Threading.Tasks;

namespace Threads.Application.Contracts.Persistence.Pattern
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task Save ( );
    }
}
