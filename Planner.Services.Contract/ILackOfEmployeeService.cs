using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface ILackOfEmployeeService
    {
        Task<LackOfEmployeeDto> GetById(int id);
        Task<List<LackOfEmployeeDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(LackOfEmployee skill);
        void Update(LackOfEmployee skill);
    }
}
