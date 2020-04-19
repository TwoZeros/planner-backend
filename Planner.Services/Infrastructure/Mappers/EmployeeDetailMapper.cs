using AutoMapper;
using Planner.Models;
using Planner.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{

    public interface IEmployeeDetailMapper : IModelMapper<EmployeeDetailDto, Employee>
    {
    }

    public class EmployeeDetailMapper : AbstractModelMapper<EmployeeDetailDto, Employee>, IEmployeeDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDetailDto, Employee>();

                cfg.CreateMap<Employee, EmployeeDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
