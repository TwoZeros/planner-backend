using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ILackOfEmployeeRepository : IBaseRepository<LackOfEmployee>
    {
        Task<List<LackOfEmployee>> GetAllLackOfEmployee();

        Task<LackOfEmployee> GetLackOfEmployeeInfo(int id);
    }
}
