using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IGroupSkillMapper : IModelMapper<GroupSkillDto, GroupSkill>
    {
    }
    public class GroupSkillMapper : AbstractModelMapper<GroupSkillDto, GroupSkill>, IGroupSkillMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GroupSkillDto, GroupSkill>();

                cfg.CreateMap<GroupSkill, GroupSkillDto>();
            });

            return config.CreateMapper();
        }
    }
}
