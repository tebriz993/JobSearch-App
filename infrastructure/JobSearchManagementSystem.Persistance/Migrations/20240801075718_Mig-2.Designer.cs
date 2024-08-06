﻿// <auto-generated />
using System;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobSearchManagementSystem.Persistance.Migrations
{
    [DbContext(typeof(JobSearchDbContext))]
    [Migration("20240801075718_Mig-2")]
    partial class Mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Companies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobDetailnformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("JobDetailnformations");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<int>("JobDetailInformationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("JobDetailInformationId");

                    b.ToTable("JobInformations");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.MaxExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("MaxExperiences");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.MinExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("MinExperiences");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Specialties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.VacancyDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("AnnouncementNumber")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatedId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedId");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobInformationId")
                        .HasColumnType("int");

                    b.Property<int>("JobTypesId")
                        .HasColumnType("int");

                    b.Property<int>("MaxExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("MinExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtiesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UpdatedId")
                        .HasColumnType("int")
                        .HasColumnName("UpdatedId");

                    b.Property<int>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobInformationId");

                    b.HasIndex("JobTypesId");

                    b.HasIndex("MaxExperienceId");

                    b.HasIndex("MinExperienceId");

                    b.HasIndex("SpecialtiesId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.UserDetail", b =>
                {
                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Account.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("JobSearchManagementSystem.Domain.Entities.Account.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.UserRole", b =>
                {
                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Account.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Account.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobInformation", b =>
                {
                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.JobDetailnformation", "JobDetailInformations")
                        .WithMany("JobInformations")
                        .HasForeignKey("JobDetailInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobDetailInformations");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Vacancy", b =>
                {
                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Companies", "Company")
                        .WithMany("Vacancies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.VacancyDetail", b =>
                {
                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Address", "Address")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Categories", "Categories")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Companies", "Company")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.JobInformation", "JobInformation")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("JobInformationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.JobTypes", "JobTypes")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("JobTypesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.MaxExperience", "MaxExperience")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("MaxExperienceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.MinExperience", "MinExperience")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("MinExperienceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Specialties", "Specialties")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobSearchManagementSystem.Domain.Entities.Jobs.Vacancy", "Vacancy")
                        .WithMany("VacancyDetails")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Categories");

                    b.Navigation("Company");

                    b.Navigation("JobInformation");

                    b.Navigation("JobTypes");

                    b.Navigation("MaxExperience");

                    b.Navigation("MinExperience");

                    b.Navigation("Specialties");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Account.User", b =>
                {
                    b.Navigation("UserDetail")
                        .IsRequired();

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Address", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Categories", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Companies", b =>
                {
                    b.Navigation("Vacancies");

                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobDetailnformation", b =>
                {
                    b.Navigation("JobInformations");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobInformation", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.JobTypes", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.MaxExperience", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.MinExperience", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Specialties", b =>
                {
                    b.Navigation("VacancyDetails");
                });

            modelBuilder.Entity("JobSearchManagementSystem.Domain.Entities.Jobs.Vacancy", b =>
                {
                    b.Navigation("VacancyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
