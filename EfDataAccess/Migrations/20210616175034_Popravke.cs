using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class Popravke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ocenas_Vrednost",
                table: "Ocenas");

            migrationBuilder.CreateIndex(
                name: "IX_Ocenas_Vrednost",
                table: "Ocenas",
                column: "Vrednost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ocenas_Vrednost",
                table: "Ocenas");

            migrationBuilder.CreateIndex(
                name: "IX_Ocenas_Vrednost",
                table: "Ocenas",
                column: "Vrednost",
                unique: true);
        }
    }
}
