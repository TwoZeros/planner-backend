using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class WorkTimeInCheduleService : IWorkTimeInCheduleService
    {
        public IWorkTimeInCheduleRepository _repo;

        private readonly IWorkTimeInSheduleDetailMapper _detailMapper;

        public WorkTimeInCheduleService(IWorkTimeInCheduleRepository repo, IWorkTimeInSheduleDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<WorkTimeInSheduleDto> GetById(int id)
        {
            var workTimeInShedule = await _repo.GetWorkTimeInCheduleInfo(id);
            var workTimeInSheduleDto = _detailMapper.Map<WorkTimeInShedule, WorkTimeInSheduleDto>(workTimeInShedule);

            return workTimeInSheduleDto;
        }
        public async Task<List<WorkTimeInSheduleDto>> GetAll()
        {
            var workTimeInShedule = await _repo.GetAllWorkTimeInChedule();
            return _detailMapper.Map<List<WorkTimeInShedule>, List<WorkTimeInSheduleDto>>(workTimeInShedule);
        }

        public async Task<string> Delete(int id)
        {
            var workTimeInShedule = await _repo.GetById(id);
            if (workTimeInShedule != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(WorkTimeInShedule workTimeInShedule)
        {
            _repo.Add(workTimeInShedule);
            await _repo.SaveAsync();
        }

        public void Update(WorkTimeInShedule workTimeInShedule)
        {
            _repo.Update(workTimeInShedule);
        }

        public async Task AddDaysShedule(WorkHoursCount workHoursCount, Shedule shedule)
        {
            var list = new List<WorkTimeInShedule>();

            var date = new DateTime(workHoursCount.Year, 1, 1);

            for (int i = 0; i < 337 + DateTime.DaysInMonth(workHoursCount.Year, 2); i++)
            {
                var wtis = new WorkTimeInShedule();
                wtis.isHoliday = false;
                wtis.SheduleId = shedule.Id;
                wtis.HolidayName = null;
                wtis.CountHours = getHours(date, workHoursCount);
                wtis.Date = date;
                date = date.AddDays(1);
                //_repo.Add(wtis);
                list.Add(wtis);
            }
            _repo.AddRange(list);
            await _repo.SaveAsync();
        }

        public int getHours(DateTime d, WorkHoursCount workHoursCount)
        {
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return workHoursCount.Sunday;
                case DayOfWeek.Monday:
                    return workHoursCount.Monday;
                case DayOfWeek.Tuesday:
                    return workHoursCount.Tuesday;
                case DayOfWeek.Wednesday:
                    return workHoursCount.Wednesday;
                case DayOfWeek.Thursday:
                    return workHoursCount.Thursday;
                case DayOfWeek.Friday:
                    return workHoursCount.Friday;
                case DayOfWeek.Saturday:
                    return workHoursCount.Saturday;
            }
            return 0;
        }
    }
}
