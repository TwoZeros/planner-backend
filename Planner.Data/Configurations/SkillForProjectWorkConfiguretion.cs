using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    public class SkillForProjectWorkConfiguretion : IEntityTypeConfiguration<SkillForProjectWork>
    {
        public void Configure(EntityTypeBuilder<SkillForProjectWork> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                   .HasOne(p => p.Skill)
                   .WithMany(t => t.SkillForProjectWork)
                   .HasForeignKey(p => p.SkillId);
            builder
                   .HasOne(p => p.ProjectWork)
                   .WithMany(t => t.SkillForProjectWork)
                   .HasForeignKey(p => p.ProjectWorkId);

        }
    }
}
