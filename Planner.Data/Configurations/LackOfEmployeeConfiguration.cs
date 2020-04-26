using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class LackOfEmployeeConfiguration
    {
        public void Configure(EntityTypeBuilder<LackOfEmployee> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Employee)
                   .WithMany(t => t.LackOfEmployees)
                   .HasForeignKey(p => p.EmployeeId);
        }
    }
}
