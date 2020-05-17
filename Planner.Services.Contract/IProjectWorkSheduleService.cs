using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IProjectWorkSheduleService
    {
        Task<ProjectWorkSheduleDto> GetById(int id);
        Task<List<ProjectWorkSheduleDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(ProjectWorkShedule projectWorkShedule);
        void Update(ProjectWorkShedule projectWorkShedule);

    }
}