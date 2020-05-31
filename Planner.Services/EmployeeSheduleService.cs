using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class EmployeeSheduleService : IEmployeeSheduleService
    {
        public IEmployeeSheduleRepository _repo;

        private readonly IEmployeeSheduleDetailMapper _detailMapper;

        public EmployeeSheduleService(IEmployeeSheduleRepository repo, IEmployeeSheduleDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<EmployeeSheduleDto> GetById(int id)
        {
            var employeeShedule = await _repo.GetEmployeeSheduleInfo(id);
            var employeeSheduleDto = _detailMapper.Map<EmployeeShedule, EmployeeSheduleDto>(employeeShedule);

            return employeeSheduleDto;
        }
        public async Task<List<EmployeeSheduleDto>> GetAll()
        {
            var employeeShedule = await _repo.GetAllEmployeeShedule();
            return _detailMapper.Map<List<EmployeeShedule>, List<EmployeeSheduleDto>>(employeeShedule);
        }

        public async Task<List<EmployeeSheduleDto>> GetSchedulesByEmployeeId(int Id)
        {
            var employeeShedule = await _repo.GetSchedulesByEmployeeId(Id);
            return _detailMapper.Map<List<EmployeeShedule>, List<EmployeeSheduleDto>>(employeeShedule);
        }

        public async Task<string> Delete(int id)
        {
            var employeeShedule = await _repo.GetById(id);
            if (employeeShedule != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(EmployeeShedule employeeShedule)
        {
            _repo.Add(employeeShedule);
            await _repo.SaveAsync();
        }

        public void Update(EmployeeShedule employeeShedule)
        {
            _repo.Update(employeeShedule);
        }
    }
}
