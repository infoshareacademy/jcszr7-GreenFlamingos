using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class FirstTableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "DbDrinkId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Wódka" },
                    { 2, null, "Rum" },
                    { 3, null, "Whisky" },
                    { 4, null, "Kostki lodu" },
                    { 5, null, "Woda" },
                    { 6, null, "Sok Pomarańczowy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrinkTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrinkTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrinkTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
