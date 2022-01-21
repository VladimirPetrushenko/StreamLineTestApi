using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;

namespace StreamLineTestApi.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly StreamLineDbContext _context;

        public RepositoryBase(StreamLineDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task CreateItem(TEntity item) =>
            await _dbSet.AddAsync(item);

        public Task DeleteItem(TEntity item)
        {
            _dbSet.Remove(item);
            return Task.CompletedTask;
        }

        public Task UpdateItem(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChanges() =>
            await _context.SaveChangesAsync() >= 0;
    }
}
