using Planner.Models;
using Planner.Services.Contract.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services.Contract
{
    public interface IProjectWorkService 
    {
        Task<ProjectWorkDto> GetById(int id);
        Task<List<ProjectWorkDto>> GetAll();
        Task<string> Delete(int id);
        Task Add(ProjectWork work);
        void Update(ProjectWork work);
    }
}
