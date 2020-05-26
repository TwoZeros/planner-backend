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
    public class SheduleService : ISheduleService
    {
        public ISheduleRepository _repo;

        private readonly ISheduleDetailMapper _detailMapper;

        public SheduleService(ISheduleRepository repo, ISheduleDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<SheduleDto> GetById(int id)
        {
            var shedule = await _repo.GetSheduleInfo(id);
            var sheduleDto = _detailMapper.Map<Shedule, SheduleDto>(shedule);

            return sheduleDto;
        }
        public async Task<List<SheduleDto>> GetAll()
        {
            var shedules = await _repo.GetAllShedule();
            return _detailMapper.Map<List<Shedule>, List<SheduleDto>>(shedules);
        }

        public async Task<string> Delete(int id)
        {
            var shedule = await _repo.GetById(id);
            if (shedule != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(Shedule shedule)
        {
            _repo.AddInstance(shedule);
            await _repo.SaveAsync();
        }

        public void Update(Shedule shedule)
        {
            _repo.Update(shedule);
        }
    }
}
