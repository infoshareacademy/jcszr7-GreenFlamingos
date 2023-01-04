using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenFlamingosApp.DataBase.Migrations
{
    public partial class Init : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AlcoholContent = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    DrinkTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbDrinks_DrinkTypes_DrinkTypeId",
                        column: x => x.DrinkTypeId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbDrinks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbDrinkUser",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDrinkUser", x => new { x.DrinkId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DbDrinkUser_DbDrinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "DbDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbDrinkUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbDrinkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_DbDrinks_DbDrinkId",
                        column: x => x.DbDrinkId,
                        principalTable: "DbDrinks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DbDrinkIngredient",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDrinkIngredient", x => new { x.DrinkId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DbDrinkIngredient_DbDrinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "DbDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbDrinkIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinkIngredient_IngredientId",
                table: "DbDrinkIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinks_AuthorId",
                table: "DbDrinks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinks_DrinkTypeId",
                table: "DbDrinks",
                column: "DrinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinks_MainIngredientId",
                table: "DbDrinks",
                column: "MainIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDrinkUser_UserId",
                table: "DbDrinkUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DbDrinkId",
                table: "Ingredients",
                column: "DbDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDetails_UserId",
                table: "UsersDetails",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbDrinkIngredient");

            migrationBuilder.DropTable(
                name: "DbDrinkUser");

            migrationBuilder.DropTable(
                name: "UsersDetails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "DbDrinks");

            migrationBuilder.DropTable(
                name: "DbMainIngredients");

            migrationBuilder.DropTable(
                name: "DrinkTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
