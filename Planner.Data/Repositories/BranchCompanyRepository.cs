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
    public class BranchCompanyRepository : BaseRepository<BranchCompany>, IBranchCompanyRepository
    {
        private readonly PlannerDbContext _context;

        public BranchCompanyRepository(PlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BranchCompany>> GetAllBranchCompany()
        {
            return await _context.BranchCompanys.ToListAsync();
        }

        public async Task<BranchCompany> GetBranchCompanyInfo(int id)
        {
            return await _context.BranchCompanys
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
