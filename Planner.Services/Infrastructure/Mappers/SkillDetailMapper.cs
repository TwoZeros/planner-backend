using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ISkillDetailMapper : IModelMapper<SkillDto, Skill>
    {
    }
    public class SkillDetailMapper : AbstractModelMapper<SkillDto, Skill>, ISkillDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillDto, Skill>();

                cfg.CreateMap<Skill, SkillDto>()
                .ForMember(x => x.GroupName, s => s.MapFrom(x => x.GroupSkill.Name));
            });

            return config.CreateMapper();
        }
    }
}
