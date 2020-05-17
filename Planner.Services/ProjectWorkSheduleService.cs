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
    public class ProjectWorkSheduleService : IProjectWorkSheduleService
    {
        public IProjectWorkSheduleRepository _repo;

        private readonly IProjectWorkSheduleDetailMapper _detailMapper;

        public ProjectWorkSheduleService(IProjectWorkSheduleRepository repo, IProjectWorkSheduleDetailMapper detailMapper)
        {
            _detailMapper = detailMapper;
            _repo = repo;
        }
        public async Task<ProjectWorkSheduleDto> GetById(int id)
        {
            var projectWorkShedule = await _repo.GetProjectWorkSheduleInfo(id);
            var projectWorkSheduleDto = _detailMapper.Map<ProjectWorkShedule, ProjectWorkSheduleDto>(projectWorkShedule);

            return projectWorkSheduleDto;
        }
        public async Task<List<ProjectWorkSheduleDto>> GetAll()
        {
            var projectWorkShedules = await _repo.GetAllProjectWorkShedule();
            return _detailMapper.Map<List<ProjectWorkShedule>, List<ProjectWorkSheduleDto>>(projectWorkShedules);
        }

        public async Task<string> Delete(int id)
        {
            var projectWorkShedule = await _repo.GetById(id);
            if (projectWorkShedule != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task Add(ProjectWorkShedule projectWorkShedule)
        {
            _repo.Add(projectWorkShedule);
            await _repo.SaveAsync();
        }

        public void Update(ProjectWorkShedule projectWorkShedule)
        {
            _repo.Update(projectWorkShedule);
        }
    }
}