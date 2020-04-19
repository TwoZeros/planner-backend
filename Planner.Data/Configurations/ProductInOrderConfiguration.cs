using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Data.Configurations
{
    public class ProductInOrderConfiguration : IEntityTypeConfiguration<ProductInOrder>
    {
        public void Configure(EntityTypeBuilder<ProductInOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder
           .HasOne(p => p.Order)
           .WithMany(t => t.ProductInOrders)
           .HasForeignKey(p => p.OrderId);

            builder
         .HasOne(p => p.Product)
         .WithMany(t => t.ProductInOrder)
         .HasForeignKey(p => p.ProductId);
        }
    }
}
