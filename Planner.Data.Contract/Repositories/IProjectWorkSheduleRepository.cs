using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IProjectWorkSheduleRepository : IBaseRepository<ProjectWorkShedule>
    {
        Task<List<ProjectWorkShedule>> GetAllProjectWorkShedule();

        Task<ProjectWorkShedule> GetProjectWorkSheduleInfo(int id);
    }
}