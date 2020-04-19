using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Planner.Models.LogEntry>
    {
        public void Configure(EntityTypeBuilder<Planner.Models.LogEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Severity).IsRequired();

            builder.Property(x => x.Message).HasMaxLength(1024).IsRequired();

            builder.Property(x => x.Date).IsRequired();
        }
    }
}
