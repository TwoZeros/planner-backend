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
    public class ProjectWorkSheduleRepository : BaseRepository<ProjectWorkShedule>, IProjectWorkSheduleRepository
    {
        private readonly PlannerDbContext _context;

        public ProjectWorkSheduleRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProjectWorkShedule>> GetAllProjectWorkShedule()
        {
            return await _context.ProjectWorkShedules.ToListAsync();
        }

        public async Task<ProjectWorkShedule> GetProjectWorkSheduleInfo(int id)
        {
            return await _context.ProjectWorkShedules
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}