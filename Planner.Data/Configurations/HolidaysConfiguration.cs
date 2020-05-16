using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class HolidaysConfiguration : IEntityTypeConfiguration<Holidays>
    {
        public void Configure(EntityTypeBuilder<Holidays> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256);

        }
    }
}
