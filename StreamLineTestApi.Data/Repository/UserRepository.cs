using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IRepository<User>
    {
        public UserRepository(StreamLineDbContext context) : base(context)
        {
        }

        public Task<List<User>> GetAll() =>
            _dbSet.AsNoTracking().ToListAsync();

        public async Task<User?> GetByID(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
