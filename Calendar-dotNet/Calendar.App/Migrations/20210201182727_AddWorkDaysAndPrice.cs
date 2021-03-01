using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendar.App.Migrations
{
    public partial class AddWorkDaysAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNonWorkDay",
                table: "Dates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkDay = table.Column<decimal>(nullable: false),
                    NonWorkDay = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropColumn(
                name: "IsNonWorkDay",
                table: "Dates");
        }
    }
}
