using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Contract.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Planner.Data.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private readonly PlannerDbContext _context;

        public SkillRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllSkill()
        {
            return await _context.Skills.Include(p => p.GroupSkill).ToListAsync();
        }

        public async Task<Skill> GetSkillInfo(int id)
        {
            return await _context.Skills.Include(p => p.GroupSkill)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}