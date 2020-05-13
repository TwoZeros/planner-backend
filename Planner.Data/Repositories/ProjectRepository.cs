using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly PlannerDbContext _context;

        public ProjectRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProject()
        {
            return await _context.Projects.Include(p => p.ProjectManager).ToListAsync();
        }

        public async Task<Project> GetProjectInfo(int id)
        {
            return await _context.Projects
                .Include(p => p.ProjectManager)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
