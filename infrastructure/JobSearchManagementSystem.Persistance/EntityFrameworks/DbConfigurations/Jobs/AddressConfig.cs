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
    public class AddressConfig:EFBaseConfigurations<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.AddressName)
                .IsRequired()
                .HasMaxLength(80);

            base.Configure(builder);
        }
    }
}
