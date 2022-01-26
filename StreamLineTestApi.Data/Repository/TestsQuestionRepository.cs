using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Repository
{
    public class TestsQuestionRepository : RepositoryBase<TestsQuestion>, IRepository<TestsQuestion>
    {
        public TestsQuestionRepository(StreamLineDbContext context)
            : base(context)
        {
        }

        public Task<List<TestsQuestion>> GetAll() =>
            _dbSet.AsNoTracking().ToListAsync();

        public Task<TestsQuestion?> GetByID(int id)
        {
            return _context.TestsQuestions.Where(t => t.Id == id)
                .Include(t => t.Answers)
                .FirstOrDefaultAsync();
        }
    }
}
