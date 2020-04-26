using AutoMapper;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IBranchCompanyDetailMapper : IModelMapper<BranchCompanyDto, BranchCompany>
    {
    }
    public class BranchCompanyDetailMapper : AbstractModelMapper<BranchCompanyDto, BranchCompany>, IBranchCompanyDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BranchCompanyDto, BranchCompany>();

                cfg.CreateMap<BranchCompany, BranchCompanyDto>()
                .ForMember(x => x.CompanyName, s => s.MapFrom(x => x.Company.Name));
            });

            return config.CreateMapper();
        }
    }
}
