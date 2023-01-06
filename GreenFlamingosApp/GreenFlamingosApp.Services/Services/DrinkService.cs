using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using GreenFlamingos.Repository;
using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingos.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DrinkRepository _drinkRepository;
        public DrinkService(IWebHostEnvironment webHostEnvironment, DrinkRepository drinkRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _drinkRepository = drinkRepository;
        }
        public async Task<List<MainIngredient>> GetAllMainIngredients()
        {
            return await _drinkRepository.GetAllMainIngredients();
        }
        public async Task<List<DrinkType>> GetAllDrinkTypes()
        {
            return await _drinkRepository.GetAllDrinkTypes();
        }
        
        public async Task AddDrink(Drink newDrink)
        {
            if (newDrink.Photo != null)
            {
                var folder = "Drinks/";
                folder += Guid.NewGuid().ToString() + "_" + newDrink.Photo.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                newDrink.ImageUrl = "/" + folder;
                newDrink.Photo.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            var mainIngredient = await _drinkRepository.GetMainIngredientByName(newDrink.MainIngredient);
            var drinkType = await _drinkRepository.GetDrinkTypeByName(newDrink.DrinkType);
            //var ingredients = newDrink.Ingredients.Select(i => new DbIngredient { Name = i.Name }).ToList();
            var drinkToAdd = new DbDrink { 
                Name = newDrink.Name,
                Capacity = newDrink.Capacity,
                AlcoholContent = newDrink.AlcoholContent,
                Calories = newDrink.Calories,
                DrinkType = drinkType,
                MainIngredient = mainIngredient,
                Preparations = newDrink.Preparation,
                Description = newDrink.Description,
                ImageUrl = newDrink.ImageUrl
            };
            await _drinkRepository.AddDrinkToDb(drinkToAdd);

            //if (newDrink.DrinkType == "Drink")
            //{
            //    var drinktoAdd = new AlcoDrink(newDrink.Name,
            //                                   newDrink.Owner,
            //                                   newDrink.MainIngredient,
            //                                   newDrink.Capacity,
            //                                   newDrink.AlcoholContent,
            //                                   newDrink.Calories,
            //                                   newDrink.Ingredients,
            //                                   newDrink.Description,
            //                                   newDrink.Preparation,
            //                                   newDrink.ImageUrl);
            //    _IdCounter++;
            //    drinktoAdd.Id = _IdCounter;
            //    DrinkRepository.drinkList.Add(drinktoAdd);
            //}
            //else if (newDrink.DrinkType == "Shot")
            //{
            //    var drinkToAdd = new Shot(newDrink.Name,
            //                              newDrink.Owner,
            //                              newDrink.MainIngredient,
            //                              newDrink.Capacity,
            //                              newDrink.AlcoholContent,
            //                              newDrink.Calories,
            //                              newDrink.Ingredients,
            //                              newDrink.Description,
            //                              newDrink.Preparation,
            //                              newDrink.ImageUrl);
            //    _IdCounter++;
            //    drinkToAdd.Id = _IdCounter;
            //    DrinkRepository.drinkList.Add(drinkToAdd);
            //}
            //else if (newDrink.DrinkType == "Koktajl")
            //{
            //    var drinkToAdd = new NoAlcoDrink(newDrink.Name,
            //                              newDrink.Owner,
            //                              newDrink.MainIngredient,
            //                              newDrink.Capacity,
            //                              newDrink.Calories,
            //                              newDrink.Ingredients,
            //                              newDrink.Description,
            //                              newDrink.Preparation,
            //                              newDrink.ImageUrl);
            //    _IdCounter++;
            //    drinkToAdd.Id = _IdCounter;
            //    DrinkRepository.drinkList.Add(drinkToAdd);

            //}
        }

        public void EditDrink(Drink drink)
        {
            var drinkToEdit = GetDrinkById(drink.Id);
            //var folder = "Drinks/";
            //folder += Guid.NewGuid().ToString() + "_" + drink.Photo.FileName;
            //var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            //drink.ImageUrl = "/" + folder;
            //drink.Photo.CopyTo(new FileStream(serverFolder, FileMode.Create));
            //drinkToEdit.Name = drink.Name;
            //drinkToEdit.Calories = drink.Calories;
            //drinkToEdit.AlcoholContent = drink.AlcoholContent;
            //drinkToEdit.MainIngredient = drink.MainIngredient;
            //drinkToEdit.Ingredients = drink.Ingredients;
            //drinkToEdit.Preparation = drink.Preparation;
            //drinkToEdit.Description = drinkToEdit.Description;
            //drinkToEdit.ImageUrl = drink.ImageUrl;
        }

        public async Task<List<Drink>> GetAllDrinks()
        {
            return await _drinkRepository.GetAllDrinks();
        }
        public async Task<Drink> GetDrinkById(int id)
        {
            var drinks = await GetAllDrinks();
            return drinks.FirstOrDefault(d => d.Id == id);
        }

        public void RemoveDrink(Drink drink)
        {
            var DrinkToRemove = GetDrinkById(drink.Id);
            //DrinkRepository.drinkList.Remove(DrinkToRemove);
        }
        public List<Drink> SearchDrink(string searchedWord)
        {
            if (searchedWord != null)
                return DrinkRepository.drinkList.Where(d => d.Name.Contains(searchedWord)).ToList();
            return DrinkRepository.drinkList;
        }

    }
}
