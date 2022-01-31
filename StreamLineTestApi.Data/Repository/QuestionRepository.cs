using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IRepository<Question>
    {
        public QuestionRepository(StreamLineDbContext context)
            : base(context)
        {
        }

        public Task<List<Question>> GetAll() =>
            _dbSet.AsNoTracking().ToListAsync();

        public Task<Question?> GetByID(int id)
        {
            return _context.Questions.Where(t => t.Id == id)
                .Include(t => t.Answers)
                .FirstOrDefaultAsync();
        }
    }
}
