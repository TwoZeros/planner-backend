using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProductListMapper : IModelMapper<ProductListDto, Product>
    {
    }

    public class ProductListMapper : AbstractModelMapper<ProductListDto, Product>, IProductListMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductListDto, Product>();

                cfg.CreateMap<Product, ProductListDto>()
                .ForMember(x => x.Price, s => s.MapFrom(x => x.Price.ToString("d")));
            });

            return config.CreateMapper();
        }
    }
}
