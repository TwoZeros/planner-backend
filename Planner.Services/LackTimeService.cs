using Planner.Data.Contract;
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
    public class LackTimeService : ILackTimeService
    {
        public ILackTimeRepository _repo;

        private readonly ILackTimeDetailMapper _detailMapper;

        public LackTimeService(ILackTimeRepository repo, ILackTimeDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<LackTimeDto> GetById(int id)
        {
            var lackTime = await _repo.GetLackTimeInfo(id);
            var lackTimeDto = _detailMapper.Map<LackTime, LackTimeDto>(lackTime);

            return lackTimeDto;
        }
        public async Task<List<LackTimeDto>> GetAll()
        {
            var lackTimes = await _repo.GetAllLackTime();
            return _detailMapper.Map<List<LackTime>, List<LackTimeDto>>(lackTimes);
        }

        public async Task<string> Delete(int id)
        {
            var lackTime = await _repo.GetById(id);
            if (lackTime != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(LackTime lackTime)
        {
            _repo.Add(lackTime);
            await _repo.SaveAsync();
        }

        public void Update(LackTime lackTime)
        {
            _repo.Update(lackTime);
        }
    }
}
