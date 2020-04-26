using Planner.Data.Contract.Base;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Repositories
{
    public interface IHolidaysRepository : IBaseRepository<Holidays>
    {
        Task<List<Holidays>> GetAllHolidays();

        Task<Holidays> GetHolidaysInfo(int id);
    }
}
