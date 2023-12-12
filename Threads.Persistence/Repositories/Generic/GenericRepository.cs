using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence.Generic;

namespace Threads.Persistence.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository (ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add (T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete (Guid Id)
        {
            var entity = await Get(Id);
            _dbContext.Remove(entity);
        }

        public async Task<bool> Exists (Guid id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get (Guid id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<IReadOnlyList<T>> GetAll ( )
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public Task Update (T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
