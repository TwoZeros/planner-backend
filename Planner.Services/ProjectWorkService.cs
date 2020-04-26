using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class ProjectWorkService : IProjectWorkService
    {
        public IProjectWorkRepository _repo;

        private readonly IProjectWorkDetailMapper _detailMapper;

        public ProjectWorkService(IProjectWorkRepository repo, IProjectWorkDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }

        public async Task<ProjectWorkDto> GetById(int id)
        {
            var project = await _repo.GetProjectWorkInfo(id);
            var projectDto = _detailMapper.Map<ProjectWork, ProjectWorkDto>(project);

            return projectDto;
        }
        public async Task<List<ProjectWorkDto>> GetAll()
        {
            var project = await _repo.GetAllProjectWork();
            return _detailMapper.Map<List<ProjectWork>, List<ProjectWorkDto>>(project);
        }

        public async Task<string> Delete(int id)
        {
            var project = await _repo.GetById(id);
            if (project != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(ProjectWork project)
        {
            _repo.Add(project);
            await _repo.SaveAsync();
        }
        public void Update(ProjectWork project)
        {
            _repo.Update(project);
        }
    }
}
