using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;


namespace Planner.Data.Configurations
{
    class CarmaConfiguration : IEntityTypeConfiguration<CarmaUser>
    {
        public void Configure(EntityTypeBuilder<CarmaUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.BeginCarma).HasMaxLength(100).IsRequired();
            builder.Property(x => x.EndCarma).HasMaxLength(100).IsRequired();

        }
    }
}
