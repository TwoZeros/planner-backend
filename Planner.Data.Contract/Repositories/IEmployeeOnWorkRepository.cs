using Planner.Data.Contract.Base;
using Planner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IEmployeeOnWorkRepository : IBaseRepository<EmployeeOnWork>
    {
        Task<List<EmployeeOnWork>> GetAllEmployeeOnWork();

        Task<EmployeeOnWork> GetEmployeeOnWorkInfo(int id);
    }
}
