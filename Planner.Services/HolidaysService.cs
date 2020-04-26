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
    public class HolidaysService : IHolidaysService
    {
        public IHolidaysRepository _repo;

        private readonly IHolidaysDetailMapper _detailMapper;

        public HolidaysService(IHolidaysRepository repo, IHolidaysDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<HolidaysDto> GetById(int id)
        {
            var holidays = await _repo.GetHolidaysInfo(id);
            var holidaysDto = _detailMapper.Map<Holidays, HolidaysDto>(holidays);

            return holidaysDto;
        }
        public async Task<List<HolidaysDto>> GetAll()
        {
            var holidays = await _repo.GetAllHolidays();
            return _detailMapper.Map<List<Holidays>, List<HolidaysDto>>(holidays);
        }

        public async Task<string> Delete(int id)
        {
            var holidays = await _repo.GetById(id);
            if (holidays != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(Holidays holidays)
        {
            _repo.Add(holidays);
            await _repo.SaveAsync();
        }

        public void Update(Holidays holidays)
        {
            _repo.Update(holidays);
        }
    }
    }
