using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesRegiter.Data.Migrations
{
    public partial class ExperienceLevelEmployeeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExperinceLevel",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExperinceLevel",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
