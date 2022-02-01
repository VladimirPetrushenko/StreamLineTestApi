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

        public Task<User?> GetByID(int id) =>
            _context.Users.FirstOrDefaultAsync(t => t.Id == id);
    }
}
