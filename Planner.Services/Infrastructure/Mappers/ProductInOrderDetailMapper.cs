using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProductInOrderDetailMapper : IModelMapper<ProductInOrderDetailDto, ProductInOrder>
    {
    }
    public class ProductInOrderDetailMapper : AbstractModelMapper<ProductInOrderDetailDto, ProductInOrder>, IProductInOrderDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductInOrderDetailDto, ProductInOrder>();

                cfg.CreateMap<ProductInOrder, ProductInOrderDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
