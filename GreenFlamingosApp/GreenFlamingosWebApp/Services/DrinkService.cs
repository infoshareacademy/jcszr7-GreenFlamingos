using GreenFlamingosApp.DataBase;
using GreenFlamingosWebApp.Models;
using GreenFlamingosWebApp.Repository;
using GreenFlamingosWebApp.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace GreenFlamingosWebApp.Services
{
    public class DrinkService : IDrinkService
    {
        private static int _IdCounter = 0;
        public void AddDrink(Drink newDrink)
        {
            if(newDrink.DrinkType == "Drink")
            {
                var drinktoAdd = new AlcoDrink(newDrink.Name,
                                               newDrink.Owner,
                                               newDrink.MainIngredient,
                                               newDrink.Capacity,
                                               newDrink.AlcoholContent,
                                               newDrink.Calories,
                                               newDrink.Ingredients,
                                               newDrink.Description,
                                               newDrink.Preparation);
                _IdCounter++;
                drinktoAdd.Id = _IdCounter;
                DrinkRepository.drinkList.Add(drinktoAdd);
            }
            else if(newDrink.DrinkType == "Shot")
            {
                var drinkToAdd = new Shot(newDrink.Name,
                                          newDrink.Owner,
                                          newDrink.MainIngredient,
                                          newDrink.Capacity,
                                          newDrink.AlcoholContent,
                                          newDrink.Calories,
                                          newDrink.Ingredients,
                                          newDrink.Description,
                                          newDrink.Preparation);
                _IdCounter++;
                drinkToAdd.Id = _IdCounter;
                DrinkRepository.drinkList.Add(drinkToAdd);
            }
        }
        public List<Drink> GetAll()
        {
            return DrinkRepository.drinkList;
        }
        public void RemoveDrink(Drink drink)
        {
            throw new NotImplementedException();
        }
        public List<Drink> SearchDrink(string searchedWord)
        {
            if (searchedWord != null)
                return DrinkRepository.drinkList.Where(d => d.Name.Contains(searchedWord)).ToList();
            return DrinkRepository.drinkList;
        }
    }
}
