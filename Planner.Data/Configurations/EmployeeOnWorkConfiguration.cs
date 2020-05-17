using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class EmployeeOnWorkConfiguration : IEntityTypeConfiguration<EmployeeOnWork>
    {
        public void Configure(EntityTypeBuilder<EmployeeOnWork> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Project)
                   .WithMany(t => t.EmployeeOnWorks)
                   .HasForeignKey(p => p.ProjectId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder
                   .HasOne(p => p.Employee)
                   .WithMany(t => t.EmployeeOnWorks)
                   .HasForeignKey(p => p.EmployeeId);


        }
    }
}