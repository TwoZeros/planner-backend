using Microsoft.EntityFrameworkCore;
using Planner.Data.Base;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Repositories
{
    public class SheduleRepository : BaseRepository<Shedule>, ISheduleRepository
    {
        private readonly PlannerDbContext _context;

        public SheduleRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Shedule>> GetAllShedule()
        {
            return await _context.Shedules.ToListAsync();
        }

        public async Task<Shedule> GetSheduleInfo(int id)
        {
            return await _context.Shedules
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void AddInstance(Shedule entity)
        {
            Shedule last = _context.Shedules.AsNoTracking().ToList().LastOrDefault();

            int id;
            if (last == null)
            {
                id = 1;
            }
            else
            {
                id = last.Id + 1;
            }

            foreach (var it in entity.WorkTimeInShedules)
            {
                it.SheduleId = id;
                _context.Add(it);
            }
            _context.Add(entity);
        }
    }
}
