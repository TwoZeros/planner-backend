using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IEmployeeSheduleDetailMapper : IModelMapper<EmployeeSheduleDto, EmployeeShedule>
    {
    }
    public class EmployeeSheduleDetailMapper : AbstractModelMapper<EmployeeSheduleDto, EmployeeShedule>, IEmployeeSheduleDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeSheduleDto, EmployeeShedule>();

                cfg.CreateMap<EmployeeShedule, EmployeeSheduleDto>()
                .ForMember(x => x.SheduleName, s => s.MapFrom(x => x.Shedule.Name))
                .ForMember(x => x.EmployeeName, s => s.MapFrom(x => x.Employee.FirstName));
            });

            return config.CreateMapper();
        }
    }
}