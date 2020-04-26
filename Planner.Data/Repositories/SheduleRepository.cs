using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class SheduleRepository : BaseRepository<Shedule>, ISheduleRepository
    {
        private readonly PlannerDbContext _context;

        public SheduleRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Shedule>> GetAllShedule()
        {
            return await _context.Shedules.Include(p => p.Name).ToListAsync();
        }

        public async Task<Shedule> GetSheduleInfo(int id)
        {
            return await _context.Shedules.Include(p => p.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
