using AutoMapper;
using Planner.Models;
using Planner.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Dto.Models;

namespace Planner.Infrastructure.Mappers.Interfaces
{

    public interface IOrderMapper : IModelMapper<OrderDto, OrderModel>
    {
    }

    public class OrderMapper : AbstractModelMapper<OrderDto, OrderModel>, IOrderMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDto, OrderModel>();

                cfg.CreateMap<OrderModel, OrderDto>();
            });

            return config.CreateMapper();
        }
    }
}
