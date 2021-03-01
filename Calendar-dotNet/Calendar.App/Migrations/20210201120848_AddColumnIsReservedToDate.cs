using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendar.App.Migrations
{
    public partial class AddColumnIsReservedToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Dates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Dates");
        }
    }
}
