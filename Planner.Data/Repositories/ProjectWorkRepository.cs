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
    public class ProjectWorkRepository : BaseRepository<ProjectWork>, IProjectWorkRepository
    {
        private readonly PlannerDbContext _context;

        public ProjectWorkRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProjectWork>> GetAllProjectWork()
        {
            return await _context.ProjectWorks.Include(p => p.StartTime).ToListAsync();
        }

        public async Task<ProjectWork> GetProjectWorkInfo(int id)
        {
            return await _context.ProjectWorks.Include(p => p.DeadlineTime)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
