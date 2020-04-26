using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Services
{
    public class SkillService : ISkillService
    {
        public ISkillRepository _repo;

        private readonly ISkillDetailMapper _detailMapper;

        public SkillService(ISkillRepository repo, ISkillDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<SkillDto> GetById(int id)
        {
            var skill = await _repo.GetSkillInfo(id);
            var skillDto = _detailMapper.Map<Skill, SkillDto>(skill) ;

            return skillDto;
        }
        public async Task<List<SkillDto>> GetAll()
        {
            var skills =await _repo.GetAllSkill();
            return _detailMapper.Map<List<Skill>, List<SkillDto>>(skills);
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
        public async Task Add(Skill skill)
        {
            _repo.Add(skill);
            await _repo.SaveAsync();
        }

        public void Update(Skill skill)
        {
            _repo.Update(skill);
        }
    }
}
