using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
       
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login).HasMaxLength(256).IsRequired();
            builder.HasAlternateKey(x => x.Login);
            
            builder.Property(x => x.Password).HasMaxLength(1024).IsRequired();

            
        }
    }
}
