using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Data.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder
           .HasOne(p => p.User)
           .WithMany(t => t.Orders)
           .HasForeignKey(p => p.UserId);

            builder
          .HasOne(p => p.Client)
          .WithMany(t => t.Orders)
          .HasForeignKey(p => p.ClientId);
            
            builder
         .HasOne(p => p.StatusOrder)
         .WithMany(t => t.Orders)
         .HasForeignKey(p => p.StatusId);
        }
    }
}
