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
    class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly PlannerDbContext _context;

        public CompanyRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _context.Companys.Include(p => p.Name).ToListAsync();
        }

        public async Task<Company> GetCompanyInfo(int id)
        {
            return await _context.Companys.Include(p => p.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
