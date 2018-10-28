using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesRegiter.Data.Migrations
{
    public partial class EmployeesPictureUrlAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Interns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Interns");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Employees");
        }
    }
}
