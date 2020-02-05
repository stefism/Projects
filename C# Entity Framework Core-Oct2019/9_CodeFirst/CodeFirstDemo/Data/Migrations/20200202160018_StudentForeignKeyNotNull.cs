using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstDemo.Data.Migrations
{
    public partial class StudentForeignKeyNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Towns_TownId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Towns_TownId",
                table: "Students",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Towns_TownId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Towns_TownId",
                table: "Students",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
