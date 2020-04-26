using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class LackTimeRepository : BaseRepository<LackTime>, ILackTimeRepository
    {
        private readonly PlannerDbContext _context;

        public LackTimeRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LackTime>> GetAllLackTime()
        {
            return await _context.LackTimes.Include(p => p.Hour).ToListAsync();
        }

        public async Task<LackTime> GetLackTimeInfo(int id)
        {
            return await _context.LackTimes.Include(p => p.Hour)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
