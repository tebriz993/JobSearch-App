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
    public class JobTypesConfig:EFBaseConfigurations<JobTypes>
    {
        public override void Configure(EntityTypeBuilder<JobTypes> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);


            base.Configure(builder);
        }
    }
}
