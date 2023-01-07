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
        public async Task<bool> AreDrinkIngredientsInDb(Drink drink)
        {
            var ingredientCounter = 0;
            foreach (var ingredient in drink.Ingredients)
            {
                var ingredientInDb = await _drinkRepository.CheckIngredientByName(ingredient.Name);
                if (ingredientInDb)
                    ingredientCounter++;
            }

            if (ingredientCounter == drink.Ingredients.Count())
            {
                return true;
            }

            return false;

        }
        public async Task<List<DbIngredient>> CreateIngredientsList(Drink drink)
        {
            var dbIngredients = new List<DbIngredient>();
            foreach (var ingredient in drink.Ingredients)
            {
                var dbIngredient = await _drinkRepository.GetIngredientByName(ingredient.Name);
                dbIngredients.Add(dbIngredient);
            }

            return dbIngredients;
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
            var dbIngredients = new List<DbIngredient>();

            if (await AreDrinkIngredientsInDb(newDrink))
            {
                dbIngredients = await CreateIngredientsList(newDrink);
            }

            //delete when user services will be added
            Random rand = new Random();
            var randuserId = rand.Next(1, 2);
            var drinkAuthor = await _drinkRepository.GetUserById(randuserId);
            var drinkToAdd = new DbDrink { 
                Name = newDrink.Name,
                Capacity = newDrink.Capacity,
                AlcoholContent = newDrink.AlcoholContent,
                Calories = newDrink.Calories,
                DrinkType = drinkType,
                MainIngredient = mainIngredient,
                Preparations = newDrink.Preparation,
                Description = newDrink.Description,
                ImageUrl = newDrink.ImageUrl,
                Author = drinkAuthor,
            };

            await _drinkRepository.AddDrinkToDb(drinkToAdd,dbIngredients);
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
            var drinks = await _drinkRepository.GetAllDrinks();
            return drinks;
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
