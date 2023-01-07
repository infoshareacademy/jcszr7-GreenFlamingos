using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase;
using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingos.Repository
{
    public class DrinkRepository
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
        public async Task<List<MainIngredient>> GetAllMainIngredients()
        {
            var dbMainIngredients = await _greenFlamingosDbContext.DbMainIngredients.ToListAsync();
            return dbMainIngredients.Select(d => new MainIngredient { Id = d.Id, Name = d.Name }).ToList();
        }
        public async Task<List<DrinkType>> GetAllDrinkTypes()
        {
            var dbDrinkTypes = await _greenFlamingosDbContext.DrinkTypes.ToListAsync();
            return dbDrinkTypes.Select(dt=> new DrinkType { Id=dt.Id, Name = dt.Name }).ToList();
        }
        public async Task<DbUser> GetUserById(int id)
        {
            return await _greenFlamingosDbContext.Users.Include(ud => ud.UserDetails)
                                                       .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task AddDrinkToDb(DbDrink drinkToAdd, List<DbIngredient> ingredients)
        {
            await _greenFlamingosDbContext.DbDrinks.AddAsync(drinkToAdd);
            foreach (var ingredient in ingredients)
            {
                var dbDrinkIngredient = new DbDrinkIngredient { Drink = drinkToAdd, Ingredient = ingredient };
                await _greenFlamingosDbContext.DrinksIngredients.AddAsync(dbDrinkIngredient);
            }
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            var dbDrinks = await _greenFlamingosDbContext.DbDrinks.Include(m=>m.MainIngredient)
                                                                  .Include(dt=>dt.DrinkType)
                                                                  .Include(a=>a.Author)
                                                                  .Include(d=>d.DrinkIngredients)
                                                                  .ThenInclude(x=>x.Ingredient)
                                                                  .ToListAsync();
            return dbDrinks.Select(dbDrinks => new Drink {
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
                Ingredients = dbDrinks.DrinkIngredients.Select(i=>i.Ingredient).Select(x => new Ingredient { Id = x.Id,Name = x.Name}).ToList()
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
    }
}
