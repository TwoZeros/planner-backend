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
    public class EmployeeOnWorkRepository : BaseRepository<EmployeeOnWork>, IEmployeeOnWorkRepository
    {
        private readonly PlannerDbContext _context;

        public EmployeeOnWorkRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeOnWork>> GetAllEmployeeOnWork()
        {
            return await _context.EmployeeOnWorks.Include(p => p.FactStart).ToListAsync();
        }

        public async Task<EmployeeOnWork> GetEmployeeOnWorkInfo(int id)
        {
            return await _context.EmployeeOnWorks.Include(p => p.FactStart)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
