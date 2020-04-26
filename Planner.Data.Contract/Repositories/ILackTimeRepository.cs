using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ILackTimeRepository : IBaseRepository<LackTime>
    {
        Task<List<LackTime>> GetAllLackTime();

        Task<LackTime> GetLackTimeInfo(int id);
    }
}
