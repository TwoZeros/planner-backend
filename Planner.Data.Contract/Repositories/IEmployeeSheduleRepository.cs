using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IEmployeeSheduleRepository : IBaseRepository<EmployeeShedule>
    {
        Task<List<EmployeeShedule>> GetAllEmployeeShedule();

        Task<EmployeeShedule> GetEmployeeSheduleInfo(int id);
    }
}
