using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Data.Configurations
{
    class BranchCompanyConfiguration : IEntityTypeConfiguration<BranchCompany>
    {
        public void Configure(EntityTypeBuilder<BranchCompany> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256);


            builder
                   .HasOne(p => p.Company)
                   .WithMany(t => t.BranchCompany)
                   .HasForeignKey(p => p.CompanyId);

        }
    }
}
