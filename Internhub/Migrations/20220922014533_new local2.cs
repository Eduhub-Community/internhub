using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internhub.Migrations
{
    public partial class newlocal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Internship");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Internship",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Internship");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Internship",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
