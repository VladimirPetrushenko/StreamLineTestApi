using Microsoft.EntityFrameworkCore;
using StreamLineTestApi.Data.Context;
using StreamLineTestApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamLineTestApi.Data.Repository
{
    public class TestsResultRepository : RepositoryBase<TestsResult>, IRepository<TestsResult>
    {
        public TestsResultRepository(StreamLineDbContext context) : base(context)
        {
        }

        public Task<List<TestsResult>> GetAll() =>
            _dbSet.AsNoTracking()
                .Include(x => x.Test)
                .Include(x => x.User)
                .ToListAsync();

        public Task<TestsResult?> GetByID(int id)=>
            _context.TestsResults.Where(x => x.Id == id)
                .Include(x => x.Test)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
    }
}
