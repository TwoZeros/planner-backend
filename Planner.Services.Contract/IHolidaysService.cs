using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IHolidaysService
    {
        Task<HolidaysDto> GetById(int id);
        Task<List<HolidaysDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(Holidays skill);
        void Update(Holidays skill);

    }
}
