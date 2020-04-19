using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers.Interfaces;

namespace Planner.Services.Infrastructure.Mappers
{
    public interface IProductInOrderListMapper : IModelMapper<ProductInOrderListDto, ProductInOrder>
    {
    }
    public class ProductInOrderListMapper : AbstractModelMapper<ProductInOrderListDto, ProductInOrder>, IProductInOrderListMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductInOrderListDto, ProductInOrder>();

                cfg.CreateMap<ProductInOrder, ProductInOrderListDto>()
                .ForMember(x => x.OrderId, s => s.MapFrom(x => x.Order.Id))
                .ForMember(x => x.ProductName, s => s.MapFrom(x => x.Product.Name))
                .ForMember(x => x.StandartPrice, s => s.MapFrom(x => x.Product.Price));
            });

            return config.CreateMapper();
        }
    }
}
