using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface ISheduleService
    {
        Task<SheduleDto> GetById(int id);
        Task<List<SheduleDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(Shedule skill);
        Task Update(Shedule skill, Contract.Holiday[] holidays);
        Task<List<WorkTimeInShedule>> GetHolidays(int id);
    }
}
