using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface ILackTimeService
    {
        Task<LackTimeDto> GetById(int id);
        Task<List<LackTimeDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(LackTime lackTime);
        void Update(LackTime lackTime);

    }
}
