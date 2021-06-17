using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class Tabelekomentariiocena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Posts_PostId",
                table: "Ocena");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Users_UserId",
                table: "Ocena");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocena",
                table: "Ocena");

            migrationBuilder.RenameTable(
                name: "Ocena",
                newName: "Ocenas");

            migrationBuilder.RenameIndex(
                name: "IX_Ocena_Vrednost",
                table: "Ocenas",
                newName: "IX_Ocenas_Vrednost");

            migrationBuilder.RenameIndex(
                name: "IX_Ocena_UserId",
                table: "Ocenas",
                newName: "IX_Ocenas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocena_PostId",
                table: "Ocenas",
                newName: "IX_Ocenas_PostId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocenas",
                table: "Ocenas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Komentars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrednost = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentars_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentars_PostId",
                table: "Komentars",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentars_UserId",
                table: "Komentars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocenas_Posts_PostId",
                table: "Ocenas",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocenas_Users_UserId",
                table: "Ocenas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocenas_Posts_PostId",
                table: "Ocenas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocenas_Users_UserId",
                table: "Ocenas");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Komentars");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocenas",
                table: "Ocenas");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Ocenas",
                newName: "Ocena");

            migrationBuilder.RenameIndex(
                name: "IX_Ocenas_Vrednost",
                table: "Ocena",
                newName: "IX_Ocena_Vrednost");

            migrationBuilder.RenameIndex(
                name: "IX_Ocenas_UserId",
                table: "Ocena",
                newName: "IX_Ocena_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocenas_PostId",
                table: "Ocena",
                newName: "IX_Ocena_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocena",
                table: "Ocena",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Posts_PostId",
                table: "Ocena",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Users_UserId",
                table: "Ocena",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
