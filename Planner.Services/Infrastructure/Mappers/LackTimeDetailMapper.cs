using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ILackTimeDetailMapper : IModelMapper<LackTimeDto, LackTime>
    {
    }
    public class LackTimeDetailMapper : AbstractModelMapper<LackTimeDto, LackTime>, ILackTimeDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LackTimeDto, LackTime>();

                cfg.CreateMap<LackTime, LackTimeDto>()
                .ForMember(x => x.LackOfEmployeeName, s => s.MapFrom(x => x.LackOfEmployee.Name))
                .ForMember(x => x.Day, s => s.MapFrom(x => x.Day.ToString()));
            });

            return config.CreateMapper();
        }
    }
}
