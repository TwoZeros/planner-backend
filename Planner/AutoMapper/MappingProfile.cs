using AutoMapper;
using System.Linq;
using Planner.Dto.Models;
using Planner.Models;
using Planner.Services.Contract.Dto;
using Planner.Services.Dto;
using Planner.Dto;

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

  

            CreateMap<SkillModel, Skill>();

            CreateMap<EmployeeSkillModel, EmployeeSkill>();
            CreateMap<ClientModel, Client>();
            CreateMap<GroupSkillModel, GroupSkill>();

            CreateMap<EmployeeModel, Employee>();

            CreateMap<ProjectModel, Project>();

            CreateMap<ProjectWorkModel, ProjectWork>();

            CreateMap<SkillForProjectWorkModel, SkillForProjectWork>();

            CreateMap<CompanyModel, Company>();

            CreateMap<BranchCompanyModel, BranchCompany>();

            CreateMap<HolidaysModel, Holidays>();

            CreateMap<WorkTimeInSheduleModel, WorkTimeInShedule>();

            CreateMap<SheduleModel, Shedule>()
                  .ForMember(x => x.Monday, s => s.MapFrom(x => x.workHoursCount.Monday))
                  .ForMember(x => x.Tuesday, s => s.MapFrom(x => x.workHoursCount.Tuesday))
                  .ForMember(x => x.Saturday, s => s.MapFrom(x => x.workHoursCount.Saturday))
                  .ForMember(x => x.Wednesday, s => s.MapFrom(x => x.workHoursCount.Wednesday))
                  .ForMember(x => x.Sunday, s => s.MapFrom(x => x.workHoursCount.Sunday))
                   .ForMember(x => x.Friday, s => s.MapFrom(x => x.workHoursCount.Friday))
                  .ForMember(x => x.Thursday, s => s.MapFrom(x => x.workHoursCount.Thursday));

            CreateMap<LackOfEmployeeModel, LackOfEmployee>();

            CreateMap<LackTimeModel, LackTime>(); 

            CreateMap<EmployeeSheduleModel, EmployeeShedule>();

            CreateMap<EmployeeOnWorkModel, EmployeeOnWork>();

            CreateMap<ProjectWorkSheduleModel, ProjectWorkShedule>();

            CreateMap<User, UserListModel>();
        }
    }
}
