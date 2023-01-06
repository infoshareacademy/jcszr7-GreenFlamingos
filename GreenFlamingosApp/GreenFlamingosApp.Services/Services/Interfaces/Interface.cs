using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingos.Services.Interfaces
{
    public interface IDrinkService
    {
        public Task<List<Drink>> GetAllDrinks();
        public Task AddDrink(Drink drink);
        public Task<Drink> GetDrinkById(int id);
        public void RemoveDrink(Drink drink);
        public List<Drink> SearchDrink(string searchedWord);
        public void EditDrink(Drink drink);
        public Task<List<MainIngredient>> GetAllMainIngredients();
        public Task<List<DrinkType>> GetAllDrinkTypes();
    }
}
