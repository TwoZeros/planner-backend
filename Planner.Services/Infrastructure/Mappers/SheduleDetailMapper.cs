using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ISheduleDetailMapper : IModelMapper<SheduleDto, Shedule>
    {
    }
    public class SheduleDetailMapper : AbstractModelMapper<SheduleDto, Shedule>, ISheduleDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SheduleDto, Shedule>();

                cfg.CreateMap<Shedule, SheduleDto>();
            });

            return config.CreateMapper();
        }
    }
}
