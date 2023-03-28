using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class EnglishIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Orange Juice");

            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Strawberry");

            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Banana");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Ice Cube");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Water");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Orange Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Tomato Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Sparkling Water");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Apple Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Currant Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Lemon Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Sugar syrup");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Grenadine");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Coke");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Lime Juice");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Lime");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Lemon");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Tomato");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Spinach");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Orange");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Pomegranate");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Mint");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Strawberry");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Avocado");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Peach");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Banana");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Honey");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "White Grape");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Red Grape");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Sok pomidorowy");

            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Truskawka");

            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Banan");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Kostki lodu");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Woda");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Sok Pomarańczowy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Sok pomidorowy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Woda Gazowana");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Sok Jabłkowy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Sok Porzeczkowy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Sok z cytryny");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Syrop cukrowy");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Grenadyna");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Coca Cola");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Sok z limonki");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Limonka");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Cytryna");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Pomidor");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Szpinak");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Pomarańcza");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Granat");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Mięta");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Truskawki");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Avokado");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Brzoskwinia");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Banan");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Miód");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Winogrono Białe");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Winogrono Czerwone");
        }
    }
}
