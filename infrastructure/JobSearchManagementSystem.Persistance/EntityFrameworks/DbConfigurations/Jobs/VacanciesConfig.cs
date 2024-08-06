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
    public class VacanciesConfig:EFBaseConfigurations<Vacancy>
    {
        public override void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(c => c.Image)
                .IsRequired();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder
               .HasOne(c => c.Company)
               .WithMany(c => c.Vacancies)
               .HasForeignKey(c => c.CompanyId);



            base.Configure(builder);
        }
    }
}
