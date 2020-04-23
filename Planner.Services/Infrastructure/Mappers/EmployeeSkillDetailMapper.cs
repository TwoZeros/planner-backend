using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IEmployeeSkillDetailMapper : IModelMapper<EmployeeSkillDto, EmployeeSkill>
    {
    }
    public class EmployeeSkillDetailMapper : AbstractModelMapper<EmployeeSkillDto, EmployeeSkill>, IEmployeeSkillDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeSkillDto, EmployeeSkill>();

                cfg.CreateMap<EmployeeSkill, EmployeeSkillDto>()
                .ForMember(x => x.KnowledgeLevelName, s => s.MapFrom(x => x.KnowledgeLevel.Name))
                .ForMember(x => x.SkillName, s => s.MapFrom(x => x.Skill.Name))
                .ForMember(x => x.SkillGroupName, s => s.MapFrom(x => x.Skill.GroupSkill.Name));
            });

            return config.CreateMapper();
        }
    }
}
