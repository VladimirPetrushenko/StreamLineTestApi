using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Data.Repository
{
    public class QuestionsAnswerRepository : RepositoryBase<QuestionsAnswer>, IRepository<QuestionsAnswer>
    {
        public QuestionsAnswerRepository(StreamLineDbContext context)
            : base(context)
        {
        }

        public Task<List<QuestionsAnswer>> GetAll() =>
            _dbSet.AsNoTracking().ToListAsync();

        public Task<QuestionsAnswer?> GetByID(int id)
        {
            return _context.QuestionsAnswers.Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
