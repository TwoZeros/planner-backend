using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ISkillForProjectsWorkDetailMapper : IModelMapper<SkillForProjectWorkDto, SkillForProjectWork>
    {
    }

    public class SkillForProjectsWorkDetailMapper : AbstractModelMapper<SkillForProjectWorkDto, SkillForProjectWork>, ISkillForProjectsWorkDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillForProjectWorkDto, SkillForProjectWork>();

                cfg.CreateMap<SkillForProjectWork, SkillForProjectWorkDto>()
                .ForMember(x => x.ProjectName, s => s.MapFrom(x => x.ProjectWork.Project.Name));
                cfg.CreateMap<SkillForProjectWork, SkillForProjectWorkDto>()
                .ForMember(x => x.SkillName, s => s.MapFrom(x => x.Skill.Name));
            });

            return config.CreateMapper();
        }
    }
}
