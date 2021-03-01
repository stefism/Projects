using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendar.App.Migrations
{
    public partial class AddUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dates_UserId",
                table: "Dates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dates_AspNetUsers_UserId",
                table: "Dates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dates_AspNetUsers_UserId",
                table: "Dates");

            migrationBuilder.DropIndex(
                name: "IX_Dates_UserId",
                table: "Dates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Dates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
