using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class seedingedited2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vodka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DbMainIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wódka");
        }
    }
}
