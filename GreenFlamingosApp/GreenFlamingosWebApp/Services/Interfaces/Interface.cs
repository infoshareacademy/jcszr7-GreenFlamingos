using GreenFlamingosWebApp.Models;

namespace GreenFlamingosWebApp.Services.Interfaces
{
    public interface IDrinkService
    {
        List<Drink> GetAll();
        void AddDrink(Drink drink);
        Drink GetDrinkById(int id);
        void RemoveDrink(Drink drink);
    }
}
