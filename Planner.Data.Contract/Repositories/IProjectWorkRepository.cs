using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IProjectWorkRepository : IBaseRepository<ProjectWork>
    {
        Task<List<ProjectWork>> GetAllProjectWork();

        Task<ProjectWork> GetProjectWorkInfo(int id);
    }
}
