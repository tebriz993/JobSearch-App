using JobSearchManagementSystem.Domain.Entities.Account;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts
{
    public class JobSearchDbContext:DbContext
    {
        public JobSearchDbContext(DbContextOptions<JobSearchDbContext> optionsBuilder) : base(optionsBuilder)
        {

        }
        
        public DbSet<Address> Address =>this.Set<Address>();
        public DbSet<Categories> Categories => this.Set<Categories>();
        public DbSet<Companies> Companies => this.Set<Companies>();
        public DbSet<JobInformation> JobInformations => this.Set<JobInformation>();
        public DbSet<JobDetailnformation> JobDetailnformations => this.Set<JobDetailnformation>();
        public DbSet<JobTypes> JobTypes => this.Set<JobTypes>();
        public DbSet<VacancyDetail> VacancyDetails => this.Set<VacancyDetail>();
        public DbSet<Vacancy> Vacancies => this.Set<Vacancy>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<Role> Role => this.Set<Role>();
        public DbSet<UserDetail> UserDetails => this.Set<UserDetail>();
        public DbSet<UserRole> UserRoles => this.Set<UserRole>();
        public DbSet<Specialties> Specialties => this.Set<Specialties>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

       
    }
}
