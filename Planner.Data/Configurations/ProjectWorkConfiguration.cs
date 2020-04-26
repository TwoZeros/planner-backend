using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class ProjectWorkConfiguration : IEntityTypeConfiguration<ProjectWork>
    {
        public void Configure(EntityTypeBuilder<ProjectWork> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Project)
                   .WithMany(t => t.ProjectWorks)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}
