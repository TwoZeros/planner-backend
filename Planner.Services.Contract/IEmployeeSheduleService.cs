using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IEmployeeSheduleService
    {
        Task<EmployeeSheduleDto> GetById(int id);
        Task<List<EmployeeSheduleDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(EmployeeShedule employeeShedule);
        void Update(EmployeeShedule employeeShedule);
    }
}
