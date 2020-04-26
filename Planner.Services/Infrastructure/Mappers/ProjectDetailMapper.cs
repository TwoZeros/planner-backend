using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Planner.Services.Infrastructure.Mappers.ProjectDetailMapper;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProjectDetailMapper : IModelMapper<ProjectDto, Project>
    {
    }

    public class ProjectDetailMapper : AbstractModelMapper<ProjectDto, Project>, IProjectDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDto, Project>();

                cfg.CreateMap<Project, ProjectDto>()
                .ForMember(x => x.ProjectManagerName, s => s.MapFrom(x => x.ProjectManager.FirstName));
            });

            return config.CreateMapper();
        }
    }
}
