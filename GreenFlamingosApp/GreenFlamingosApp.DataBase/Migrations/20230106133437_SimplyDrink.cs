using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class SimplyDrink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbMainIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbMainIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DbDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbDrinks_DbMainIngredients_MainIngredientId",
                        column: x => x.MainIngredientId,
                        principalTable: "DbMainIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbDrinks_DrinkTypes_DrinkTypeId",
                        column: x => x.DrinkTypeId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DbMainIngredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wódka" },
                    { 2, "Rum" },
                    { 3, "Whisky" },
                    { 4, "Sok pomidorowy" }
                });

            migrationBuilder.InsertData(
                table: "DrinkTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drink z alkoholem" },
                    { 2, "Shot" },
                    { 3, "Drink bezalkoholowy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinks_DrinkTypeId",
                table: "DbDrinks",
                column: "DrinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinks_MainIngredientId",
                table: "DbDrinks",
                column: "MainIngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbDrinks");

            migrationBuilder.DropTable(
                name: "DbMainIngredients");

            migrationBuilder.DropTable(
                name: "DrinkTypes");
        }
    }
}
