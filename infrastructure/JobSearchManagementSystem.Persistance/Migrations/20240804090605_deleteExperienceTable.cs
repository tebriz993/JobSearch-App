using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchManagementSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class deleteExperienceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDetails_MaxExperiences_MaxExperienceId",
                table: "VacancyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyDetails_MinExperiences_MinExperienceId",
                table: "VacancyDetails");

            migrationBuilder.DropTable(
                name: "MaxExperiences");

            migrationBuilder.DropTable(
                name: "MinExperiences");

            migrationBuilder.DropIndex(
                name: "IX_VacancyDetails_MaxExperienceId",
                table: "VacancyDetails");

            migrationBuilder.DropIndex(
                name: "IX_VacancyDetails_MinExperienceId",
                table: "VacancyDetails");

            migrationBuilder.DropColumn(
                name: "MaxExperienceId",
                table: "VacancyDetails");

            migrationBuilder.DropColumn(
                name: "MinExperienceId",
                table: "VacancyDetails");

            migrationBuilder.AddColumn<byte>(
                name: "MaxExperience",
                table: "VacancyDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinExperience",
                table: "VacancyDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxExperience",
                table: "VacancyDetails");

            migrationBuilder.DropColumn(
                name: "MinExperience",
                table: "VacancyDetails");

            migrationBuilder.AddColumn<int>(
                name: "MaxExperienceId",
                table: "VacancyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinExperienceId",
                table: "VacancyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaxExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaxExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinExperiences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyDetails_MaxExperienceId",
                table: "VacancyDetails",
                column: "MaxExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyDetails_MinExperienceId",
                table: "VacancyDetails",
                column: "MinExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDetails_MaxExperiences_MaxExperienceId",
                table: "VacancyDetails",
                column: "MaxExperienceId",
                principalTable: "MaxExperiences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyDetails_MinExperiences_MinExperienceId",
                table: "VacancyDetails",
                column: "MinExperienceId",
                principalTable: "MinExperiences",
                principalColumn: "Id");
        }
    }
}
