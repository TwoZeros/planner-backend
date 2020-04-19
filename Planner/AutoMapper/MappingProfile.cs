using AutoMapper;
using System.Linq;
using Planner.Dto.Models;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Dto;

namespace Planner.AutoMapper
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<OrderModel, OrderDto>();

            CreateMap<Employee, EmployeeListDto>()
              .ForMember(x => x.Login, s => s.MapFrom(x => x.User.Login))
              .ForMember(x => x.BirthDay, s => s.MapFrom(x => x.BirthDay.ToString("d"))) 
              .ForMember(x => x.Created, s => s.MapFrom(x => x.CreatedDate.ToString("d")));

  

            CreateMap<Employee, EmployeeDetailDto>();
                //.ForMember(x => x.EmployeeContact, s => s.MapFrom( u => u.EmployeeContact));


        }
    }
}
