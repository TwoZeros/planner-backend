using Planner.Data.Contract.Base;
using Planner.Models;
using Planner.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IWorkTimeInCheduleRepository : IBaseRepository<WorkTimeInShedule>
    {
        Task<List<WorkTimeInShedule>> GetAllWorkTimeInChedule();

        Task<WorkTimeInShedule> GetWorkTimeInCheduleInfo(int id);

        Task<List<WorkTimeInShedule>> GetDaysByShedyle(int id);

        void DeleteShedules(Shedule shedule);
        Task<List<WorkTimeInShedule>> GetHolidaysInfo(int id);
    }
}
