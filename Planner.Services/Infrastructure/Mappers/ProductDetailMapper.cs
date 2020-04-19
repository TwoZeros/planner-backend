using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProductDetailMapper : IModelMapper<ProductDetailDto, Product>
    {
    }
    public class ProductDetailMapper : AbstractModelMapper<ProductDetailDto, Product>, IProductDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDetailDto, Product>();

                cfg.CreateMap<Product, ProductDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
