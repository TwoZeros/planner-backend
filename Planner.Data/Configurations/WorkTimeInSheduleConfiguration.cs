using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class WorkTimeInSheduleConfiguration : IEntityTypeConfiguration<WorkTimeInShedule>
    {
        public void Configure(EntityTypeBuilder<WorkTimeInShedule> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Shedule)
                   .WithMany(t => t.WorkTimeInShedules)
                   .HasForeignKey(p => p.SheduleId);
        }
    }
}
