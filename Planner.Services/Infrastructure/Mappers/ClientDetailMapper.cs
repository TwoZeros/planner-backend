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

    public interface IClientDetailMapper : IModelMapper<ClientDetailDto, Client>
    {
    }

    public class ClientDetailMapper : AbstractModelMapper<ClientDetailDto, Client>, IClientDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDetailDto, Client>();

                cfg.CreateMap<Client, ClientDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
