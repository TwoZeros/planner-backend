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
    public class SkillForProjectWorkService : ISkillForProjectWorkService
    {
        public ISkillForProjectsWorkRepository _repo;

        private readonly ISkillForProjectsWorkDetailMapper _detailMapper;

        public SkillForProjectWorkService(ISkillForProjectsWorkRepository repo, ISkillForProjectsWorkDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<SkillForProjectWorkDto> GetById(int id)
        {
            var skill = await _repo.GetSkillForProjectsWorkInfo(id);
            var skillDto = _detailMapper.Map<SkillForProjectWork, SkillForProjectWorkDto>(skill);

            return skillDto;
        }
        public async Task<List<SkillForProjectWorkDto>> GetAll()
        {
            var skills = await _repo.GetAllSkillForProjectsWork();
            return _detailMapper.Map<List<SkillForProjectWork>, List<SkillForProjectWorkDto>>(skills);
        }

        public async Task<string> Delete(int id)
        {
            var skill = await _repo.GetById(id);
            if (skill != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(SkillForProjectWork skill)
        {
            _repo.Add(skill);
            await _repo.SaveAsync();
        }

        public void Update(SkillForProjectWork skill)
        {
            _repo.Update(skill);
        }
    }
}
