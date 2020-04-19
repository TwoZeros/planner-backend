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
    public class CarmaRepository : BaseRepository<CarmaUser>, ICarmaRepository
    {
        private readonly PlannerDbContext _context;

        public CarmaRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<CarmaUser> GetStatusByNumber(int number)
        {
            return await _context.CarmaUsers
                .AsNoTracking()
                .Where(b => b.BeginCarma <= number && b.EndCarma >= number)
                .FirstOrDefaultAsync();


        }

        public void PutCarmaClient(CarmaUser carmaUser)
        {
            _context.Entry(carmaUser)
           .Property(i => i.Name).IsModified = true;
            _context.Entry(carmaUser)
                .Property(i => i.BeginCarma).IsModified = true;
            _context.Entry(carmaUser)
                .Property(i => i.EndCarma).IsModified = true;
        }
    }
}