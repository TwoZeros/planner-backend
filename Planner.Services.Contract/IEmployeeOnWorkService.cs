using Planner.Models;
using Planner.Services.Contract.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IEmployeeOnWorkService
    {
        Task<EmployeeOnWorkDto> GetById(int id);
        Task<List<EmployeeOnWorkDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(EmployeeOnWork employeeOnWork);
        void Update(EmployeeOnWork employeeOnWork);
    }
}
