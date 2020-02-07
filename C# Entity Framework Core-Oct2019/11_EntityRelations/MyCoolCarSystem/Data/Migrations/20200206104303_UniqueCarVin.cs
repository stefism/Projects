using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCoolCarSystem.Data.Migrations
{
    public partial class UniqueCarVin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_Vin",
                table: "Cars",
                column: "Vin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Vin",
                table: "Cars");
        }
    }
}
