using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;


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
                   .HasForeignKey(p => p.ProjectId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder
                   .HasOne(p => p.Employee)
                   .WithMany(t => t.ProjectWorks)
                   .HasForeignKey(p => p.EmployeeId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder
                   .HasOne(p => p.ProjectWorkShedule)
                   .WithMany(t => t.ProjectWorks)
                   .HasForeignKey(p => p.ProjectWorkSheduleId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}