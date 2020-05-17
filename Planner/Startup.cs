using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Planner.AutoMapper;
using Planner.Common;
using Planner.Data;
using Planner.Infrastructure;
using Planner.Infrastructure.Mappers.Interfaces;
using Planner.Services;
using Serilog.Extensions.Logging.File;
using Swashbuckle.AspNetCore;

using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using Planner.Services.Infrastructure.Mappers;

namespace Planner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<PlannerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Planner.Data")));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            //SingltonMapper
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Common
            services.Configure<LoggerSettings>(Configuration.GetSection("LoggerSettings"));

            // Mappers
            services.AddTransient<IOrderMapper, OrderMapper>();
            
            services.AddTransient<IEmployeeDetailMapper, EmployeeDetailMapper>();
            services.AddTransient<IEmployeeListMapper, EmployeeListMapper>();
            services.AddTransient<ISkillDetailMapper, SkillDetailMapper>();
            services.AddTransient<ISkillForProjectsWorkDetailMapper, SkillForProjectsWorkDetailMapper>();
            services.AddTransient<IGroupSkillMapper, GroupSkillMapper>();
            services.AddTransient<IEmployeeSkillDetailMapper, EmployeeSkillDetailMapper>();
            services.AddTransient<IClientListMapper, ClientListMapper>();
            services.AddTransient<IClientDetailMapper, ClientDetailMapper>();
            services.AddTransient<ICommentListMapper, CommentListMapper>();
            services.AddTransient<ICommentDetailMapper, CommentDetailMapper>();
            services.AddTransient<IProjectDetailMapper, ProjectDetailMapper>();
            services.AddTransient<IProjectWorkDetailMapper, ProjectWorkDetailMapper>();
            services.AddTransient<IBranchCompanyDetailMapper, BranchCompanyDetailMapper>();
            services.AddTransient<ICompanyDetailMapper, CompanyDetailMapper>();
            services.AddTransient<IHolidaysDetailMapper, HolidaysDetailMapper>();
            services.AddTransient<IWorkTimeInSheduleDetailMapper, WorkTimeInSheduleDetailMapper>();
            services.AddTransient<ISheduleDetailMapper, SheduleDetailMapper>();
            services.AddTransient<ILackOfEmployeeDetailMapper, LackOfEmployeeDetailMapper>();
            services.AddTransient<ILackTimeDetailMapper, LackTimeDetailMapper>(); 
            services.AddTransient<IEmployeeSheduleDetailMapper, EmployeeSheduleDetailMapper>();
            services.AddTransient<IEmployeeOnWorkDetailMapper, EmployeeOnWorkDetailMapper>();
            services.AddTransient<IProjectWorkSheduleDetailMapper, ProjectWorkSheduleDetailMapper>();

            // Services
            Services.Infrastructure.ContainerConfiguration.Configure(services);
            Services.Infrastructure.AuthorisationConfiguration.Configure(services);
            Services.Infrastructure.SwaggerConfiguration.Configure(services);

            services.AddTransient<IProductListMapper, ProductListMapper>();
            services.AddTransient<IProductDetailMapper, ProductDetailMapper>();
            services.AddTransient<IOrderListMapper, OrderListMapper>();
            services.AddTransient<IOrderDetailMapper, OrderDetailMapper>();
            services.AddTransient<IProductInOrderListMapper, ProductInOrderListMapper>();
            services.AddTransient<IProductInOrderDetailMapper, ProductInOrderDetailMapper>();
            services.AddControllers();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
      options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
  );

            logger.LogInformation("Processing request ");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
