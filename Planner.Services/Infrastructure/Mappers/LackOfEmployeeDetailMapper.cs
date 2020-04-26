using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ILackOfEmployeeDetailMapper : IModelMapper<LackOfEmployeeDto, LackOfEmployee>
    {
    }
    public class LackOfEmployeeDetailMapper : AbstractModelMapper<LackOfEmployeeDto, LackOfEmployee>, ILackOfEmployeeDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LackOfEmployeeDto, LackOfEmployee>();

                cfg.CreateMap<LackOfEmployee, LackOfEmployeeDto>()
                .ForMember(x => x.EmployeeName, s => s.MapFrom(x => x.Employee.FirstName));
            });

            return config.CreateMapper();
        }
    }
}
