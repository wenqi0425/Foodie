using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Migrations
{
    public partial class removeWrapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wrapper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wrapper",
                columns: table => new
                {
                    WrapperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    RecipeItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wrapper", x => x.WrapperId);
                    table.ForeignKey(
                        name: "FK_Wrapper_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wrapper_RecipeItems_RecipeItemId",
                        column: x => x.RecipeItemId,
                        principalTable: "RecipeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wrapper_RecipeId",
                table: "Wrapper",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wrapper_RecipeItemId",
                table: "Wrapper",
                column: "RecipeItemId");
        }
    }
}
