using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces
{
    public interface IDrinkRepository
    {
        public Task<DbMainIngredient> GetMainIngredientByName(string name);
        public Task<DbDrinkType> GetDrinkTypeByName(string name);
        public Task<List<DbMainIngredient>> GetAllDbMainIngredients();
        public Task<List<DbIngredient>> GetAllDbIngredients();
        public Task<List<DbDrinkType>> GetAllDbDrinkTypes();
        public Task<List<DbDrink>> GetDbDrinksByMainIngredient(string mainIngredient);
        public Task AddDrinkToDb(DbDrink drinkToAdd, List<DbIngredient> ingredients, List<string> ingredientsCapacity);
        public Task<List<Drink>> GetAllDrinks();
        public Task<bool> CheckIngredientByName(string name);
        public Task<DbIngredient> GetIngredientByName(string name);
        public Task RemoveDrinkFromDB(int id);
        public Task<DbDrink> GetDrinkById(int id);
        public Task EditDrinkinDB(DbDrink drink, List<DbIngredient> ingredients, List<string> ingredientsCapacity);
        public Task AddDrinkToFavourites(DbUser user, DbDrink drink);
        public Task AddRateToDrink(DbUser user, DbDrink drink, int rating);
        public Task<Dictionary<DbDrink, decimal>> GetTopRatedDrinks();
        public Task<List<DbDrink>> GetFavouriteDrinks(DbUser dbUser);
        public Task<Dictionary<int, decimal>> GetDrinkIdRatingDicotnary();
    }
}
