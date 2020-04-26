using Microsoft.Extensions.DependencyInjection;
using Planner.Data.Contract.Repositories;
using Planner.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
namespace Planner.Data.Infrastructure
{
   public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICarmaRepository, CarmaRepository>();
            services.AddTransient<IEmployeePositionRepository, EployeePositionRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductInOrderRepository, ProductInOrderRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectWorkRepository, ProjectWorkRepository>();
            services.AddTransient<ISkillForProjectsWorkRepository, SkillForProjectsWorkRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IBranchCompanyRepository, BranchCompanyRepository>();
            services.AddTransient<IHolidaysRepository, HolidaysRepository>();
            services.AddTransient<IWorkTimeInCheduleRepository, WorkTimeInCheduleRepository>();
            services.AddTransient<ISheduleRepository, SheduleRepository>();
            services.AddTransient<ILackOfEmployeeRepository, LackOfEmployeeRepository>();
            services.AddTransient<ILackTimeRepository, LackTimeRepository>();
            services.AddTransient<IEmployeeSheduleRepository, EmployeeSheduleRepository>();
            services.AddTransient<IEmployeeOnWorkRepository, EmployeeOnWorkRepository>();
        }
   }
}
