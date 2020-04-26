using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class LackTimeConfiguration : IEntityTypeConfiguration<LackTime>
    {
        public void Configure(EntityTypeBuilder<LackTime> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.LackOfEmployee)
                   .WithMany(t => t.LackTimes)
                   .HasForeignKey(p => p.LackOfEmployeeId);
        }
    }
}
