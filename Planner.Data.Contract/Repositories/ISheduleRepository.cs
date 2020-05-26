using Planner.Data.Contract.Base;
using Planner.Models;
using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface ISheduleRepository : IBaseRepository<Shedule>
    {
        Task<List<Shedule>> GetAllShedule();

        Task<Shedule> GetSheduleInfo(int id);

        void AddInstance(Shedule entity);
    }
}
