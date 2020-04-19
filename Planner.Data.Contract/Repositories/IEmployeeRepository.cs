using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        List<Employee> GetListEmployee();
        Task<Employee> GetEmployeeInfo(int id);
        void PutEmployee(Employee employee);
        void PutEmployeePhoto(Employee employee);
    }
    
}
