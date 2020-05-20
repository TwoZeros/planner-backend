
using Microsoft.Extensions.DependencyInjection;
using Planner.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Services;

namespace Planner.Services.Infrastructure
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            Planner.Data.Infrastructure.ContainerConfiguration.Configure(services);
            services.AddTransient<ILoggerService, LoggerService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProjectWorkService, ProjectWorkService>();
            services.AddTransient<ISkillForProjectWorkService, SkillForProjectWorkService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IBranchCompanyService, BranchCompanyService>();
            services.AddTransient<IHolidaysService, HolidaysService>();
            services.AddTransient<IEmployeeSheduleService, EmployeeSheduleService>();
            services.AddTransient<ILackOfEmployeeService, LackOfEmployeeService>();
            services.AddTransient<ILackTimeService, LackTimeService>();
            services.AddTransient<IWorkTimeInCheduleService, WorkTimeInCheduleService>();
            services.AddTransient<ISheduleService, SheduleService>();
            services.AddTransient<IEmployeeOnWorkService, EmployeeOnWorkService>();
            services.AddTransient<IProjectWorkSheduleService, ProjectWorkSheduleService>();

            services.AddTransient<ICarmaUser, CarmaUserService>(); 

            services.AddTransient<IEmployeePositionService, EmployeePositionServices>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductInOrderService, ProductInOrderService>();
            services.AddTransient<IUserManagerService, UserManagerService>();
        }
    }
}
