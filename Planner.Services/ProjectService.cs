using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class ProjectService : IProjectService
    {
        public IProjectRepository _repo;

        private readonly IProjectDetailMapper _detailMapper;

        public ProjectService(IProjectRepository repo, IProjectDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }

        public async Task<ProjectDto> GetById(int id)
        {
            var project = await _repo.GetProjectInfo(id);
            var projectDto = _detailMapper.Map<Project, ProjectDto>(project);

            return projectDto;
        }
        public async Task<List<ProjectDto>> GetAll()
        {
            var project = await _repo.GetAllProject();
            return _detailMapper.Map<List<Project>, List<ProjectDto>>(project);
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
        public async Task Add(Project project)
        {
            _repo.Add(project);
            await _repo.SaveAsync();
        }
        public void Update(Project project)
        {
            _repo.Update(project);
        }
    }
}
