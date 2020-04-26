using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IWorkTimeInSheduleDetailMapper : IModelMapper<WorkTimeInSheduleDto, WorkTimeInShedule>
    {
    }
    public class WorkTimeInSheduleDetailMapper : AbstractModelMapper<WorkTimeInSheduleDto, WorkTimeInShedule>, IWorkTimeInSheduleDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkTimeInSheduleDto, WorkTimeInShedule>();

                cfg.CreateMap<WorkTimeInShedule, WorkTimeInSheduleDto>()
                .ForMember(x => x.SheduleName, s => s.MapFrom(x => x.Shedule.Name));
            });

            return config.CreateMapper();
        }
    }
}
