using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internhub.Migrations
{
    public partial class addlocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Internship",
                table: "Internship");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Internship",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "InternshipId",
                table: "Internship",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Internship",
                table: "Internship",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_Id",
                table: "Internship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Internship_AspNetUsers_Id",
                table: "Internship",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internship_AspNetUsers_Id",
                table: "Internship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Internship",
                table: "Internship");

            migrationBuilder.DropIndex(
                name: "IX_Internship_Id",
                table: "Internship");

            migrationBuilder.DropColumn(
                name: "InternshipId",
                table: "Internship");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Internship",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Internship",
                table: "Internship",
                column: "Id");
        }
    }
}
