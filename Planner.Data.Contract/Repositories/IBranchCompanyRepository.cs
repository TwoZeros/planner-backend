using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IBranchCompanyRepository : IBaseRepository<BranchCompany>
    {
        Task<List<BranchCompany>> GetAllBranchCompany();

        Task<BranchCompany> GetBranchCompanyInfo(int id);
    }
}
