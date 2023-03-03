using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class AddProposelDrinkTablesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DbProposedDrinkId",
                table: "DrinkUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProposedDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AlcoholContent = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    DrinkTypeId = table.Column<int>(type: "int", nullable: false),
                    MainIngredientId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Preparations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposedDrinks_AspNetUsers_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProposedDrinks_DbMainIngredients_MainIngredientId",
                        column: x => x.MainIngredientId,
                        principalTable: "DbMainIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposedDrinks_DrinkTypes_DrinkTypeId",
                        column: x => x.DrinkTypeId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposedDrinkIngriedents",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedDrinkIngriedents", x => new { x.DrinkId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ProposedDrinkIngriedents_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposedDrinkIngriedents_ProposedDrinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "ProposedDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkUsers_DbProposedDrinkId",
                table: "DrinkUsers",
                column: "DbProposedDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedDrinkIngriedents_IngredientId",
                table: "ProposedDrinkIngriedents",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedDrinks_AuthorId1",
                table: "ProposedDrinks",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedDrinks_DrinkTypeId",
                table: "ProposedDrinks",
                column: "DrinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedDrinks_MainIngredientId",
                table: "ProposedDrinks",
                column: "MainIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkUsers_ProposedDrinks_DbProposedDrinkId",
                table: "DrinkUsers",
                column: "DbProposedDrinkId",
                principalTable: "ProposedDrinks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkUsers_ProposedDrinks_DbProposedDrinkId",
                table: "DrinkUsers");

            migrationBuilder.DropTable(
                name: "ProposedDrinkIngriedents");

            migrationBuilder.DropTable(
                name: "ProposedDrinks");

            migrationBuilder.DropIndex(
                name: "IX_DrinkUsers_DbProposedDrinkId",
                table: "DrinkUsers");

            migrationBuilder.DropColumn(
                name: "DbProposedDrinkId",
                table: "DrinkUsers");
        }
    }
}
