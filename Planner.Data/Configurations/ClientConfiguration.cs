﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Data.Configurations
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
       
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
                                   
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);

            builder.Property(x => x.Email).HasMaxLength(60);

        }
    }
}
