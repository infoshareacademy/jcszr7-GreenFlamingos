using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly GreenFlamingosDbContext _greenFlamingosDbContext;
        public DrinkRepository(GreenFlamingosDbContext greenFlamingosDbContext)
        {
            _greenFlamingosDbContext = greenFlamingosDbContext;
        }
        public async Task<DbMainIngredient> GetMainIngredientByName(string name)
        {
            return await _greenFlamingosDbContext.DbMainIngredients.FirstOrDefaultAsync(dm => dm.Name == name);
        }
        public async Task<DbDrinkType> GetDrinkTypeByName(string name)
        {
            return await _greenFlamingosDbContext.DrinkTypes.FirstOrDefaultAsync(dm => dm.Name == name);
        }
        public async Task<List<DbMainIngredient>> GetAllDbMainIngredients()
        {
            return await _greenFlamingosDbContext.DbMainIngredients.ToListAsync();
        }
        public async Task<List<DbIngredient>> GetAllDbIngredients()
        {
            return await _greenFlamingosDbContext.Ingredients.ToListAsync();
        }
        public async Task<List<DbDrinkType>> GetAllDbDrinkTypes()
        {
            return await _greenFlamingosDbContext.DrinkTypes.ToListAsync();
        }
        public async Task<List<DbDrink>> GetDbDrinksByMainIngredient(string mainIngredient)
        {
            var drinkType = await GetDrinkTypeByName("Drink z alkoholem");
            return await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                          .Include(dt => dt.DrinkType)
                                                          .Include(a => a.Author)
                                                          .Include(d => d.DrinkIngredients)
                                                          .ThenInclude(x => x.Ingredient)
                                                          .Where(db => db.MainIngredient.Name == mainIngredient && db.DrinkType.Name == drinkType.Name)
                                                          .ToListAsync();
        }
        public async Task AddDrinkToDb(DbDrink drinkToAdd, List<DbIngredient> ingredients, List<string> ingredientsCapacity)
        {
            await _greenFlamingosDbContext.DbDrinks.AddAsync(drinkToAdd);
            foreach (var ingredient in ingredients)
            {
                var dbDrinkIngredient = new DbDrinkIngredient { Drink = drinkToAdd, Ingredient = ingredient, IngredientCapacity = ingredientsCapacity[ingredients.IndexOf(ingredient)] };
                await _greenFlamingosDbContext.DrinksIngredients.AddAsync(dbDrinkIngredient);
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            var dbDrinks = await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                                  .Include(dt => dt.DrinkType)
                                                                  .Include(a => a.Author)
                                                                  .Include(d => d.DrinkIngredients)
                                                                  .ThenInclude(x => x.Ingredient)
                                                                  .ToListAsync();

            return dbDrinks.Select(dbDrinks => new Drink
            {
                Id = dbDrinks.Id,
                Name = dbDrinks.Name,
                DrinkType = dbDrinks.DrinkType.Name,
                MainIngredient = dbDrinks.MainIngredient.Name,
                Capacity = dbDrinks.Capacity,
                AlcoholContent = dbDrinks.AlcoholContent,
                Preparation = dbDrinks.Preparations,
                Calories = dbDrinks.Calories,
                Description = dbDrinks.Description,
                ImageUrl = dbDrinks.ImageUrl,
                Ingredients = dbDrinks.DrinkIngredients.Select(i => new
                {
                    SimplyIngredient = i.Ingredient,
                    SimplyIngredientCapacity = i.IngredientCapacity
                })
                                                       .Select(x => new Ingredient
                                                       {
                                                           Name = x.SimplyIngredient.Name,
                                                           Capacity = x.SimplyIngredientCapacity
                                                       }).ToList()
            }).ToList();
        }
        public async Task<bool> CheckIngredientByName(string name)
        {
            return await _greenFlamingosDbContext.Ingredients.AnyAsync(dm => dm.Name == name);
        }
        public async Task<DbIngredient> GetIngredientByName(string name)
        {
            return await _greenFlamingosDbContext.Ingredients.FirstOrDefaultAsync(i => i.Name == name);
        }
        public static List<Drink> drinkList { get; set; }
        public async Task RemoveDrinkFromDB(int id)
        {
            var drinkToRemove = await _greenFlamingosDbContext.DbDrinks.FirstOrDefaultAsync(d => d.Id == id);
            _greenFlamingosDbContext.DbDrinks.Remove(drinkToRemove);
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        public async Task<DbDrink> GetDrinkById(int id)
        {
            return await _greenFlamingosDbContext.DbDrinks.FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task EditDrinkinDB(DbDrink drink, List<DbIngredient> ingredients, List<string> ingredientsCapacity)
        {
            var drinkToEdit = await GetDrinkById(drink.Id);
            foreach (var ingredient in ingredients)
            {
                if (await _greenFlamingosDbContext.DrinksIngredients.AnyAsync(di => di.IngredientId == ingredient.Id && di.DrinkId == drink.Id))
                {
                    var drinkIngredientToEdit = await _greenFlamingosDbContext.DrinksIngredients.FirstOrDefaultAsync(di => di.IngredientId == ingredient.Id && di.DrinkId == drink.Id);
                    drinkIngredientToEdit.Drink = drink;
                    drinkIngredientToEdit.Ingredient = ingredient;
                    drinkIngredientToEdit.IngredientCapacity = ingredientsCapacity[ingredients.IndexOf(ingredient)];
                }
                else
                {
                    var newDrinkIngredient = new DbDrinkIngredient
                    {
                        Drink = drink,
                        Ingredient = ingredients[ingredients.IndexOf(ingredient)],
                        IngredientCapacity = ingredientsCapacity[ingredients.IndexOf(ingredient)]
                    };
                    await _greenFlamingosDbContext.DrinksIngredients.AddAsync(newDrinkIngredient);
                }
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
            var drinkIngredientsToEdit = await _greenFlamingosDbContext.DrinksIngredients.Where(di => di.DrinkId == drink.Id).ToListAsync();

            foreach (var drinkIngredient in drinkIngredientsToEdit)
            {
                if (!ingredients.Any(i => i.Id == drinkIngredient.IngredientId))
                {
                    _greenFlamingosDbContext.Remove(drinkIngredient);
                    await _greenFlamingosDbContext.SaveChangesAsync();
                }
            }
            drinkToEdit = drink;
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        public async Task AddDrinkToFavourites(DbUser user, DbDrink drink)
        {
            var userFavouriteDrink = new DbDrinkUser { Drink = drink, User = user };
            await _greenFlamingosDbContext.DrinkUsers.AddAsync(userFavouriteDrink);
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
    }
}
