using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Claims;

namespace GreenFlamingos.Services.Services.Interfaces
{
    public interface IDrinkService
    {
        public Task<List<Drink>> GetAllDrinks();
        public Task AddDrink(Drink drink);
        public Task<Drink> GetDrinkById(int id);
        public  Task RemoveDrink(Drink drink);
       // public List<Drink> SearchDrink(string searchedWord);
        public Task EditDrink(Drink drink);
        public Task<List<MainIngredient>> GetAllMainIngredients();
        public Task<List<DrinkType>> GetAllDrinkTypes();
        public Task<List<Ingredient>> GetAllIngredients();
        public Task<List<Drink>> GetDrinksByMainIngredient(string mainIngredient);
        public Task AddDrinkToFavourites(int drinkId, Claim userId);
        public Task AddRateToDrink(int drinkId, Claim userId, int rateToAdd);
        public Task<Dictionary<DbDrink, int>> GetTopRatedDrinks();
        public Task<List<Drink>> GetFavouriteDrinks(Claim userId);
        public Task<List<Drink>> GetSearchedDrinks(string searchedPhrase);
    }
}
