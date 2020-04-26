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
    public class LackOfEmployeeService : ILackOfEmployeeService
    {
        public ILackOfEmployeeRepository _repo;

        private readonly ILackOfEmployeeDetailMapper _detailMapper;

        public LackOfEmployeeService(ILackOfEmployeeRepository repo, ILackOfEmployeeDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        
        public async Task<LackOfEmployeeDto> GetById(int id)
        {
            var lackOfEmployee = await _repo.GetLackOfEmployeeInfo(id);
            var lackOfEmployeeDto = _detailMapper.Map<LackOfEmployee, LackOfEmployeeDto>(lackOfEmployee);

            return lackOfEmployeeDto;
        }
        public async Task<List<LackOfEmployeeDto>> GetAll()
        {
            var lackOfEmployee = await _repo.GetAllLackOfEmployee();
            return _detailMapper.Map<List<LackOfEmployee>, List<LackOfEmployeeDto>>(lackOfEmployee);
        }

        public async Task<string> Delete(int id)
        {
            var lackOfEmployee = await _repo.GetById(id);
            if (lackOfEmployee != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(LackOfEmployee lackOfEmployee)
        {
            _repo.Add(lackOfEmployee);
            await _repo.SaveAsync();
        }

        public void Update(LackOfEmployee lackOfEmployee)
        {
            _repo.Update(lackOfEmployee);
        }
    }
}
