using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IEmployeeOnWorkDetailMapper : IModelMapper<EmployeeOnWorkDto, EmployeeOnWork>
    {
    }
    public class EmployeeOnWorkDetailMapper : AbstractModelMapper<EmployeeOnWorkDto, EmployeeOnWork>, IEmployeeOnWorkDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeOnWorkDto, EmployeeOnWork>();

                cfg.CreateMap<EmployeeOnWork, EmployeeOnWorkDto>()
                .ForMember(x => x.EmployeeName, s => s.MapFrom(x => x.Employee.FirstName))
                .ForMember(x => x.ProjectName, s => s.MapFrom(x => x.Project.Name));
            });

            return config.CreateMapper();
        }
    }
}
