using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

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
            var RatingAverage = new List<decimal>();
            var dictonaryRating = await GetDrinkIdRatingDicotnary();

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
                AverageRating = dictonaryRating.FirstOrDefault(r => r.Key == dbDrinks.Id).Value,
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
            var drinkUser = _greenFlamingosDbContext.DrinkUsers.FirstOrDefault(du => du.DrinkId == drink.Id && du.UserId == user.Id);
            if (drinkUser == null)
            {
                var userFavouriteDrink = new DbDrinkUser { Drink = drink, User = user, Rating = 0, IsFavourite = true };
                await _greenFlamingosDbContext.DrinkUsers.AddAsync(userFavouriteDrink);
            }
            else
            {
                drinkUser.IsFavourite = true;
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
        }

        public async Task AddRateToDrink(DbUser user, DbDrink drink, int rating)
        {
            var drinkUser = _greenFlamingosDbContext.DrinkUsers.FirstOrDefault(du => du.DrinkId == drink.Id && du.UserId == user.Id);
            if (drinkUser == null)
            {
                var userFavouriteDrink = new DbDrinkUser { Drink = drink, User = user, Rating = rating, IsFavourite = false };
                await _greenFlamingosDbContext.DrinkUsers.AddAsync(userFavouriteDrink);
            }
            else
            {
                drinkUser.Rating = rating;
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        
        public async Task<Dictionary<int,decimal>> GetDrinkIdRatingDicotnary()
        {
            return await _greenFlamingosDbContext.DrinkUsers.GroupBy(u => u.DrinkId)
                .Select(r => new KeyValuePair<int, decimal>(r.Key, (decimal)r.Average(x => x.Rating)))
                .ToDictionaryAsync(x => x.Key, y => y.Value);
        }

        public async Task<Dictionary<DbDrink, decimal>> GetTopRatedDrinks()

        {
            var drinkRates = await GetDrinkIdRatingDicotnary();

            Dictionary<DbDrink, decimal> resultDictionary = new Dictionary<DbDrink, decimal>();

            foreach (var drinkRate in drinkRates)
            {
                resultDictionary[await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                                  .Include(dt => dt.DrinkType)
                                                                  .Include(a => a.Author)
                                                                  .Include(d => d.DrinkIngredients).ThenInclude(x => x.Ingredient)
                                                                  .FirstOrDefaultAsync(x => x.Id == drinkRate.Key)] = drinkRate.Value;
            }
            return resultDictionary.Where(d => d.Value > 0).OrderByDescending(d => d.Value).ToDictionary(x => x.Key, y => y.Value);

        }

        public async Task<Dictionary<DbDrink, decimal>> Get6TopRatedDrinks()

        {
            var drinkRates = await GetDrinkIdRatingDicotnary();

            Dictionary<DbDrink, decimal> resultDictionary = new Dictionary<DbDrink, decimal>();

            foreach (var drinkRate in drinkRates)
            {
                resultDictionary[await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                                  .Include(dt => dt.DrinkType)
                                                                  .Include(a => a.Author)
                                                                  .Include(d => d.DrinkIngredients).ThenInclude(x => x.Ingredient)
                                                                  .FirstOrDefaultAsync(x => x.Id == drinkRate.Key)] = drinkRate.Value;
            }

            return resultDictionary.Where(d => d.Value > 0).OrderByDescending(d => d.Value).Take(6).ToDictionary(x => x.Key, y => y.Value);
        }

        public async Task<List<DbDrink>> GetFavouriteDrinks(DbUser dbUser)
        {
            return await _greenFlamingosDbContext.DrinkUsers.Include(du => du.Drink).ThenInclude(d => d.MainIngredient)
                                                                 .Include(du => du.Drink).ThenInclude(d => d.DrinkType)
                                                                 .Include(du => du.Drink).ThenInclude(d => d.Author)
                                                                 .Include(du => du.Drink).ThenInclude(d => d.DrinkIngredients).ThenInclude(i => i.Ingredient)
                                                                 .Where(du => du.UserId == dbUser.Id && du.IsFavourite == true)
                                                                 .Select(du=>du.Drink)
                                                                 .ToListAsync();
        }

        public async Task<List<DbDrink>> GetMatchedDrinks(DrinkMatch drinkMatch)
        {
            var dbMainIngredientsDrinkMatched = await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                                  .Include(dt => dt.DrinkType)
                                                                  .Include(a => a.Author)
                                                                  .Include(d => d.DrinkIngredients).ThenInclude(x => x.Ingredient)
                                                                  .Where(d => d.MainIngredient.Name == drinkMatch.MainIngredient)
                                                                  .ToListAsync();
            var dbDrinkMatched = new List<DbDrink>();

            foreach (var drink in dbMainIngredientsDrinkMatched)
            {
                foreach (var ingredient in drinkMatch.Ingredients)
                {
                    if(drink.DrinkIngredients.Any(i=>i.Ingredient.Name == ingredient))
                    {
                        dbDrinkMatched.Add(drink);
                        break;
                    }

                }
            }
            return dbDrinkMatched;
        }

        public async Task<List<DbDrink>> GetDbDrinksShotsByMainIngredient(string mainIngredient)
        {
            var drinkType = await GetDrinkTypeByName("Shot");
            return await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                          .Include(dt => dt.DrinkType)
                                                          .Include(a => a.Author)
                                                          .Include(d => d.DrinkIngredients)
                                                          .ThenInclude(x => x.Ingredient)
                                                          .Where(db => db.MainIngredient.Name == mainIngredient && db.DrinkType.Name == drinkType.Name)
                                                          .ToListAsync();
        }

        public async Task<List<DbDrink>> GetDbDrinksNoAlcoByMainIngredient(string mainIngredient)
        {
            var drinkType = await GetDrinkTypeByName("Drink bezalkoholowy");
            return await _greenFlamingosDbContext.DbDrinks.Include(m => m.MainIngredient)
                                                          .Include(dt => dt.DrinkType)
                                                          .Include(a => a.Author)
                                                          .Include(d => d.DrinkIngredients)
                                                          .ThenInclude(x => x.Ingredient)
                                                          .Where(db => db.MainIngredient.Name == mainIngredient && db.DrinkType.Name == drinkType.Name)
                                                          .ToListAsync();
        }

        public async Task AddIngredientsToDB(List<DbIngredient> dbIngredients)
        {
            foreach(var dbIngredient in dbIngredients)
            {
                await _greenFlamingosDbContext.Ingredients.AddAsync(dbIngredient);
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
    }
}
