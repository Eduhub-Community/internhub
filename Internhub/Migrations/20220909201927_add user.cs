using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internhub.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Organization",
                table: "AspNetUsers",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Full Name");

            migrationBuilder.AddColumn<string>(
                name: "Company Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompany",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Internship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobTitle = table.Column<string>(name: "Job Title", type: "text", nullable: false),
                    JobDescription = table.Column<string>(name: "Job Description", type: "text", nullable: false),
                    NOP = table.Column<int>(type: "integer", nullable: false),
                    QualificationEducation = table.Column<string>(name: "Qualification/Education", type: "text", nullable: false),
                    Experience = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false),
                    LastDateToApply = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<string>(type: "text", nullable: true),
                    JobType = table.Column<string>(name: "Job Type", type: "text", nullable: false),
                    Companyname = table.Column<string>(name: "Company name", type: "text", nullable: false),
                    ComapnyLogo = table.Column<string>(name: "Comapny Logo", type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internship", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Internship");

            migrationBuilder.DropColumn(
                name: "Company Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsCompany",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "AspNetUsers",
                newName: "Organization");

            migrationBuilder.RenameColumn(
                name: "Full Name",
                table: "AspNetUsers",
                newName: "Name");
        }
    }
}
