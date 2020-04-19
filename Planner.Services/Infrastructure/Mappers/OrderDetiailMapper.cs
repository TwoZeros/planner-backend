using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IOrderDetailMapper : IModelMapper<OrderDetailDto, Order>
    {
    }

    public class OrderDetailMapper : AbstractModelMapper<OrderDetailDto, Order>, IOrderDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetailDto, Order>();

                cfg.CreateMap<Order, OrderDetailDto>()
                .ForMember(x => x.StatusId, s => s.MapFrom(x => x.StatusOrder.Id))
                .ForMember(x => x.UserId, s => s.MapFrom(x => x.User.Id))
                .ForMember(x => x.ClientId, s => s.MapFrom(x => x.Client.Id));
            });

            return config.CreateMapper();
        }
    }
}
