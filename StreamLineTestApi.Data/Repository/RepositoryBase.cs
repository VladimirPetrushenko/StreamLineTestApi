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

        public async Task<TEntity> CreateItem(TEntity item)
        {
            var model = await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        public async Task DeleteItem(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(TEntity item)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChanges() =>
            await _context.SaveChangesAsync() >= 0;
    }
}
