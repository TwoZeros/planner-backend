using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<List<Skill>> GetAllSkill();

        Task<Skill> GetSkillInfo(int id);
    }
}
