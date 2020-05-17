using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProjectWorkSheduleDetailMapper : IModelMapper<ProjectWorkSheduleDto, ProjectWorkShedule>
    {
    }
    public class ProjectWorkSheduleDetailMapper : AbstractModelMapper<ProjectWorkSheduleDto, ProjectWorkShedule>, IProjectWorkSheduleDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectWorkSheduleDto, ProjectWorkShedule>();

                cfg.CreateMap<ProjectWorkShedule, ProjectWorkSheduleDto>()
                .ForMember(x => x.Day, s => s.MapFrom(x => x.Day.ToString("d")));
            });

            return config.CreateMapper();
        }
    }
}