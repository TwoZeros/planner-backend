using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<WorkTimeInShedule>> GetDaysByShedyle(int id)
        {
            return await _context.WorkTimeInChedules.Where(p => p.SheduleId == id).OrderBy(p => p.Date).ToListAsync();
        }
        public void DeleteShedules(Shedule shedule) 
        {
            var _shedule = _context.WorkTimeInChedules.Where(p => p.SheduleId == shedule.Id);
            DeleteRange(_shedule);
        }
        public async Task<List<WorkTimeInShedule>> GetHolidaysInfo(int id)
        {
            return await _context.WorkTimeInChedules.Where(p => p.isHoliday == true && p.SheduleId == id).ToListAsync();
        }
    }
}
