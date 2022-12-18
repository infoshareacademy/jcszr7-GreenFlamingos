using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingos.Services.Interfaces
{
    public interface IDrinkService
    {
        List<Drink> GetAll();
        void AddDrink(Drink drink);
        Drink GetDrinkById(int id);
        void RemoveDrink(Drink drink);
        List<Drink> SearchDrink(string searchedWord);
        void EditDrink(Drink drink);
        List<MainIngredient> GetAllMainIngredient();
    }
}
