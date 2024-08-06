using JobSearchManagementSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Common
{
    public class EFBaseConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.Property(p => p.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired();
            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UpdatedDate")
                .IsRequired();
            builder.Property(p => p.CreatedId)
                .HasColumnName("CreatedId")
                .IsRequired();
            builder.Property(p => p.UpdatedId)
                .HasColumnName("UpdatedId")
                .IsRequired();
        }
    }
}
