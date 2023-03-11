using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class MainIngredientSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DbMainIngredients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Truskawka" });

            migrationBuilder.InsertData(
                table: "DbMainIngredients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Banan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
