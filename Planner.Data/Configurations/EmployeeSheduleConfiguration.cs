using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class EmployeeSheduleConfiguration : IEntityTypeConfiguration<EmployeeShedule>
    {
        public void Configure(EntityTypeBuilder<EmployeeShedule> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Employee)
                   .WithMany(t => t.EmployeeShedules)
                   .HasForeignKey(p => p.EmployeeId);
            builder
                   .HasOne(p => p.Shedule)
                   .WithMany(t => t.EmployeeShedules)
                   .HasForeignKey(p => p.SheduleId);
        }
    }
}
