using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Services
{

    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _repo;

        private readonly IEmployeeDetailMapper _detailMapper;
        private readonly IEmployeeListMapper _listMapper;
        public EmployeeService(IEmployeeRepository repo, IEmployeeDetailMapper detailMapper, IEmployeeListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;

        }

        public async Task<EmployeeDetailDto> GetById(int id)
        {
            var employee = await _repo.GetEmployeeInfo(id);
            var employeeDto = _detailMapper.Map<Employee, EmployeeDetailDto>(employee);

            return employeeDto;
        }

        public List<EmployeeListDto> GetAll()
        {
            var employee = _repo.GetListEmployee();
            return _listMapper.Map<List<Employee>, List<EmployeeListDto>>(employee);
        }

        public async Task<string> Delete(int id)
        {
            var employee = await _repo.GetEmployeeInfo(id);
            if (employee != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";

        }
        public async Task AddEmployee(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            _repo.Add(employee);
            await _repo.SaveAsync();
        }

        public void PutEmployee(int id, Employee employee)
        {
            _repo.PutEmployee(employee);
        }
        public void PutEmployeePhoto(int id, Employee employee)
        {
            _repo.PutEmployeePhoto(employee);
        }
    }
}
