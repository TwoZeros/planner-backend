using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    class ProjectWorkSheduleConfigurations : IEntityTypeConfiguration<ProjectWorkShedule>
    {
        public void Configure(EntityTypeBuilder<ProjectWorkShedule> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}