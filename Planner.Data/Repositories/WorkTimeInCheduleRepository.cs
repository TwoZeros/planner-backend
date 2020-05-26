using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class WorkTimeInCheduleRepository : BaseRepository<WorkTimeInShedule>, IWorkTimeInCheduleRepository
    {
        private readonly PlannerDbContext _context;

        public WorkTimeInCheduleRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<WorkTimeInShedule>> GetAllWorkTimeInChedule()
        {
            return await _context.WorkTimeInChedules.ToListAsync();
        }

        public async Task<WorkTimeInShedule> GetWorkTimeInCheduleInfo(int id)
        {
            return await _context.WorkTimeInChedules
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        
    }
}
