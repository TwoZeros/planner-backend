using Planner.Models;
using Planner.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IProjectService
    {
        Task<ProjectDto> GetById(int id);
        Task<List<ProjectDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(Project project);
        void Update(Project project);
    }
}
