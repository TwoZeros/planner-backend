using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<List<Project>> GetAllProject();

        Task<Project> GetProjectInfo(int id);
    }
}
