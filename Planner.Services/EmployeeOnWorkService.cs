using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class EmployeeOnWorkService : IEmployeeOnWorkService
    {
        public IEmployeeOnWorkRepository _repo;

        private readonly IEmployeeOnWorkDetailMapper _detailMapper;

        public EmployeeOnWorkService(IEmployeeOnWorkRepository repo, IEmployeeOnWorkDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<EmployeeOnWorkDto> GetById(int id)
        {
            var employeeOnWork = await _repo.GetEmployeeOnWorkInfo(id);
            var employeeOnWorkDto = _detailMapper.Map<EmployeeOnWork, EmployeeOnWorkDto>(employeeOnWork);

            return employeeOnWorkDto;
        }
        public async Task<List<EmployeeOnWorkDto>> GetAll()
        {
            var employeeOnWorks = await _repo.GetAllEmployeeOnWork();
            return _detailMapper.Map<List<EmployeeOnWork>, List<EmployeeOnWorkDto>>(employeeOnWorks);
        }

        public async Task<string> Delete(int id)
        {
            var employeeOnWork = await _repo.GetById(id);
            if (employeeOnWork != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(EmployeeOnWork employeeOnWork)
        {
            _repo.Add(employeeOnWork);
            await _repo.SaveAsync();
        }

        public void Update(EmployeeOnWork employeeOnWork)
        {
            _repo.Update(employeeOnWork);
        }
    }
}
