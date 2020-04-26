using Planner.Models;
using Planner.Services.Contract.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface ISkillForProjectWorkService
    {
        Task<SkillForProjectWorkDto> GetById(int id);
        Task<List<SkillForProjectWorkDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(SkillForProjectWork skill);
        void Update(SkillForProjectWork skill);

    }
}
