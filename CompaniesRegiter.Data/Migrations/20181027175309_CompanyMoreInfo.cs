using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesRegiter.Data.Migrations
{
    public partial class CompanyMoreInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Companies");
        }
    }
}
