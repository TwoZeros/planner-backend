using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<List<Company>> GetAllCompany();

        Task<Company> GetCompanyInfo(int id);
    }
}
