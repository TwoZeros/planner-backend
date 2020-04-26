using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;

namespace Planner.Data.Configurations
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Description).HasMaxLength(512);


            builder
                   .HasOne(p => p.ProjectManager)
                   .WithMany(t => t.Projects)
                   .HasForeignKey(p => p.ProjectManagerId);
        }
    }
}
