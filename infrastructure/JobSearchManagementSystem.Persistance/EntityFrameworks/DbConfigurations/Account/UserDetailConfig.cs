using JobSearchManagementSystem.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.DbConfigurations.Account
{
    public class UserDetailConfig : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(70);
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x => x.ProfilePicture).IsRequired(false);
        }
    }
}
