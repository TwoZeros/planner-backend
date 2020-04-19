using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Models;

namespace Planner.Data.Configurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
       
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder
           .HasOne(p => p.User)
           .WithMany(t => t.Comments)
           .HasForeignKey(p => p.UserId);

            builder
          .HasOne(p => p.Client)
          .WithMany(t => t.Comments)
          .HasForeignKey(p => p.ClientId);
        }
    }
}
