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
        public async Task AddDrinkToDb(DbDrink drinkToAdd)
        {
            await _greenFlamingosDbContext.DbDrinks.AddAsync(drinkToAdd);
            await _greenFlamingosDbContext.SaveChangesAsync();
        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            var dbDrinks = await _greenFlamingosDbContext.DbDrinks.Include(m=>m.MainIngredient)
                                                                  .Include(dt=>dt.DrinkType)
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
                ImageUrl = dbDrinks.ImageUrl
            }).ToList();
        }
        public static List<Drink> drinkList = new List<Drink>();
    }
}
