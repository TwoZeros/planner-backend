using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class EmployeeSheduleRepository : BaseRepository<EmployeeShedule>, IEmployeeSheduleRepository
    {
        private readonly PlannerDbContext _context;

        public EmployeeSheduleRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeShedule>> GetAllEmployeeShedule()
        {
            return await _context.EmployeeShedules
                .Include(p => p.Shedule).Include(p => p.Employee).ToListAsync();
        }
        public async Task<List<EmployeeShedule>> GetSchedulesByEmployeeId(int id)
        {
            return await _context.EmployeeShedules.Where(p => p.EmployeeId ==id)
                .Include(p => p.Shedule).Include(p => p.Employee).ToListAsync();
        }

        public async Task<EmployeeShedule> GetEmployeeSheduleInfo(int id)
        {
            return await _context.EmployeeShedules
                .Include(p => p.Shedule)
                .Include(p => p.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}