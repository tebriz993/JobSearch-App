using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Jobs
{
    public class VacancyDetailConfig : EFBaseConfigurations<VacancyDetail>
    {
        public override void Configure(EntityTypeBuilder<VacancyDetail> builder)
        {
            builder.Property(c => c.Image)
                .IsRequired();

            builder
              .HasOne(c => c.Vacancy)
              .WithMany(c => c.VacancyDetails)
              .HasForeignKey(c => c.VacancyId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.Property(c => c.AnnouncementNumber)
                .IsRequired();

            builder
               .HasOne(c => c.Company)
               .WithMany(c => c.VacancyDetails)
               .HasForeignKey(c => c.CompanyId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(c => c.JobInformation)
               .WithMany(c => c.VacancyDetails)
               .HasForeignKey(c => c.JobInformationId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(c => c.Address)
               .WithMany(c => c.VacancyDetails)
               .HasForeignKey(c => c.AddressId)
               .OnDelete(DeleteBehavior.NoAction);

           builder.Property(x=>x.MinExperience)
                .IsRequired();
            builder.Property(x => x.MaxExperience)
                .IsRequired();

            builder
               .HasOne(c => c.Categories)
               .WithMany(c => c.VacancyDetails)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(c => c.JobTypes)
               .WithMany(c => c.VacancyDetails)
               .HasForeignKey(c => c.JobTypesId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
              .HasOne(c => c.Specialties)
              .WithMany(c => c.VacancyDetails)
              .HasForeignKey(c => c.SpecialtiesId)
              .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
