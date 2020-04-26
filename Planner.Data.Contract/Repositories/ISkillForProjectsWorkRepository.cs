using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ISkillForProjectsWorkRepository : IBaseRepository<SkillForProjectWork>
    {
        Task<List<SkillForProjectWork>> GetAllSkillForProjectsWork();

        Task<SkillForProjectWork> GetSkillForProjectsWorkInfo(int id);
    }
}
