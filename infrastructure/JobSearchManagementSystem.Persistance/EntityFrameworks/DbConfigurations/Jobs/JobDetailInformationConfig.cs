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
    public class JobDetailInformationConfig:EFBaseConfigurations<JobDetailnformation>
    {
        public override void Configure(EntityTypeBuilder<JobDetailnformation> builder)
        {
            builder.Property(c => c.Title)
                .IsRequired();


            base.Configure(builder);
        }
    }
}
