using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IHolidaysDetailMapper : IModelMapper<HolidaysDto, Holidays>
    {
    }
    public class HolidaysDetailMapper : AbstractModelMapper<HolidaysDto, Holidays>, IHolidaysDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HolidaysDto, Holidays>();

                cfg.CreateMap<Holidays, HolidaysDto>()
                .ForMember(x => x.BranchCompanyName, s => s.MapFrom(x => x.BranchCompany.Name));
            });

            return config.CreateMapper();
        }
    }
}
