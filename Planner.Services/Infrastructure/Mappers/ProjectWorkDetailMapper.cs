using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProjectWorkDetailMapper : IModelMapper<ProjectWorkDto, ProjectWork>
    {
    }
    public class ProjectWorkDetailMapper : AbstractModelMapper<ProjectWorkDto, ProjectWork>, IProjectWorkDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectWorkDto, ProjectWork>();

                cfg.CreateMap<ProjectWork, ProjectWorkDto>();
            });

            return config.CreateMapper();
        }
    }
}
