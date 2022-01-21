using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Repository
{
    public class TestRepository : RepositoryBase<Test>, IRepository<Test>
    {
        public TestRepository(StreamLineDbContext context)
            : base(context)
        {
        }

        public Task<List<Test>> GetAll() =>
            _dbSet.AsNoTracking().ToListAsync();

        public async Task<Test?> GetByID(int id)
        {
            return await _context.Tests.Where(t => t.Id == id)
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync();
        }
            
    }
}
