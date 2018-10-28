using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesRegiter.Data.Migrations
{
    public partial class ExperienceLevelEmployeeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExperinceLevel",
                table: "Employees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperinceLevel",
                table: "Employees");
        }
    }
}
