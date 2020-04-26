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
    public class LackOfEmployeeRepository : BaseRepository<LackOfEmployee>, ILackOfEmployeeRepository
    {
        private readonly PlannerDbContext _context;

        public LackOfEmployeeRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LackOfEmployee>> GetAllLackOfEmployee()
        {
            return await _context.LackOfEmployees.Include(p => p.Name).ToListAsync();
        }

        public async Task<LackOfEmployee> GetLackOfEmployeeInfo(int id)
        {
            return await _context.LackOfEmployees.Include(p => p.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
