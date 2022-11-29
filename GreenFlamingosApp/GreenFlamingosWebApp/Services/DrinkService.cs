using GreenFlamingosApp.DataBase;
using GreenFlamingosWebApp.Models;
using GreenFlamingosWebApp.Repository;
using GreenFlamingosWebApp.Services.Interfaces;

namespace GreenFlamingosWebApp.Services
{
    public class DrinkService : IDrinkService
    {
        private static int _IdCounter = 0;
        public void AddDrink(Drink drink)
        {
            _IdCounter++;
            drink.Id = _IdCounter;
            DrinkRepository.drinkList.Add(drink);
        }
        public List<Drink> GetAll()
        {
           // drinkList = GreenFlamingosDataBaseService.ReadAllDrinks();
            return DrinkRepository.drinkList;
        }
        public void RemoveDrink(Drink drink)
        {
            throw new NotImplementedException();
        }
    }
}
