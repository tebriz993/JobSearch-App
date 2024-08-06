using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Jobs
{
    public class CompaniesConfig:EFBaseConfigurations<Companies>
    {
        public override void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder.Property(c => c.Image)
                .IsRequired();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
