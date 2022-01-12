using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;

namespace StreamLineTestApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly StreamLineDbContext _context;

        public Repository(StreamLineDbContext context)
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

        public IEnumerable<TEntity> GetAll() =>
            _dbSet.AsNoTracking();

        public async Task<TEntity?> GetByID(int id) =>
            await _dbSet.FindAsync(id);

        public Task UpdateItem(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChanges() =>
            await _context.SaveChangesAsync() >= 0;
    }
}
