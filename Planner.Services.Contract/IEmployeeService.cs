using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Models;
using Planner.Services.Contract.Dto;

namespace Planner.Services.Contract
{
    public interface IEmployeeService
    {
        public Task<EmployeeDetailDto> GetById(int id);

        public List<EmployeeListDto> GetAll();
        public Task<string> Delete(int id);

        public Task AddEmployee(Employee employee);

        public void PutEmployee(int id, Employee employee);

        public void PutEmployeePhoto(int id, Employee employee);
    }
}
