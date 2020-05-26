using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IWorkTimeInCheduleService
    {
        Task<WorkTimeInSheduleDto> GetById(int id);
        Task<List<WorkTimeInSheduleDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(WorkTimeInShedule workTimeInShedule);
        void Update(WorkTimeInShedule workTimeInShedule);
        public Task AddDaysShedule(WorkHoursCount workHoursCount, Shedule shedule);
        public int getHours(DateTime d, WorkHoursCount workHoursCount);
    }
}
