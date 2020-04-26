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
    public class HolidaysRepository : BaseRepository<Holidays>, IHolidaysRepository
    {
        private readonly PlannerDbContext _context;

        public HolidaysRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Holidays>> GetAllHolidays()
        {
            return await _context.Holidays.Include(p => p.Name).ToListAsync();
        }

        public async Task<Holidays> GetHolidaysInfo(int id)
        {
            return await _context.Holidays.Include(p => p.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
