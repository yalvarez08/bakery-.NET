using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetBakery.Migrations
{
    public partial class AddYearsofServiceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yearsOfService",
                table: "Bakers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yearsOfService",
                table: "Bakers");
        }
    }
}
