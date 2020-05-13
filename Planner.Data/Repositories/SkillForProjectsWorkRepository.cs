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
    public class SkillForProjectsWorkRepository : BaseRepository<SkillForProjectWork>, ISkillForProjectsWorkRepository
    {
        private readonly PlannerDbContext _context;

        public SkillForProjectsWorkRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SkillForProjectWork>> GetAllSkillForProjectsWork()
        {
            return await _context.SkillForProjectWorks.Include(p => p.Skill).ToListAsync();
        }

        public async Task<SkillForProjectWork> GetSkillForProjectsWorkInfo(int id)
        {
            return await _context.SkillForProjectWorks
                .Include(p => p.Skill)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
