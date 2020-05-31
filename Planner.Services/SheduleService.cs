using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class SheduleService : ISheduleService
    {
        public ISheduleRepository _repo;

        private readonly ISheduleDetailMapper _detailMapper;

        private IWorkTimeInCheduleRepository _workRepo;

        private IWorkTimeInCheduleService _workService;
        public SheduleService(ISheduleRepository repo, ISheduleDetailMapper detailMapper, IWorkTimeInCheduleRepository workRepo, IWorkTimeInCheduleService workService)
        {
            _detailMapper = detailMapper;
            _repo = repo;
            _workRepo = workRepo;
            _workService = workService;
        }
        public async Task<SheduleDto> GetById(int id)
        {
            var shedule = await _repo.GetSheduleInfo(id);
            var sheduleDto = _detailMapper.Map<Shedule, SheduleDto>(shedule);

            return sheduleDto;
        }
        public async Task<List<SheduleDto>> GetAll()
        {
            var shedules = await _repo.GetAllShedule();
            return _detailMapper.Map<List<Shedule>, List<SheduleDto>>(shedules);
        }

        public async Task<string> Delete(int id)
        {
            var shedule = await _repo.GetById(id);
            if (shedule != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(Shedule shedule)
        {
            _repo.Add(shedule);
            await _repo.SaveAsync();
        }

        public async Task Update(Shedule shedule, Contract.Holiday[] holidays)
        {
            
            _workRepo.DeleteShedules(shedule);

            _repo.Update(shedule);

            await _workService.AddDaysShedule(new WorkHoursCount()
            {
                Monday = shedule.Monday,
                Thursday = shedule.Thursday,
                Tuesday = shedule.Tuesday,
                Wednesday = shedule.Wednesday,
                Friday = shedule.Friday,
                Saturday = shedule.Saturday,
                Sunday = shedule.Sunday
            }, shedule, holidays);
        }
        public async Task<List<WorkTimeInShedule>> GetHolidays(int id)
        {
            return await _workRepo.GetHolidaysInfo(id);
        }
    }
}
