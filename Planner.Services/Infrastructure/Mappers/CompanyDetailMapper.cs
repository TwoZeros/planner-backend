using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface ICompanyDetailMapper : IModelMapper<CompanyDto, CompanyService>
    {
    }
    public class CompanyDetailMapper : AbstractModelMapper<CompanyDto, CompanyService>, ICompanyDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompanyDto, CompanyService>();

                cfg.CreateMap<CompanyService, CompanyDto>();
            });

            return config.CreateMapper();
        }
    }
}
