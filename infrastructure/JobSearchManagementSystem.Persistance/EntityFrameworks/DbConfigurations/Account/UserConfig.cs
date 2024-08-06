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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Email)
                .IsRequired();


            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.UserDetail).WithOne(x => x.User).HasForeignKey<UserDetail>(x => x.UserId);

        }
    }
}
