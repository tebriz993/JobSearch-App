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
    public class JobInformationConfig:EFBaseConfigurations<JobInformation>
    {
        public override void Configure(EntityTypeBuilder<JobInformation> builder)
        {
            builder.Property(c => c.Title)
                .IsRequired();

            builder
                .HasOne(c => c.JobDetailInformations)
                .WithMany(c => c.JobInformations)
                .HasForeignKey(c => c.JobDetailInformationId);

            base.Configure(builder);
        }
    }
}
