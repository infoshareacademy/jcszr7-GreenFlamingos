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

        public List<MainIngredient> GetAllMainIngredients()
        {
            var dbMainIngredients = _greenFlamingosDbContext.DbMainIngredients.ToList();
            return dbMainIngredients.Select(d => new MainIngredient { Id = d.Id, Name = d.Name }).ToList();
        }
        public static List<Drink> drinkList = new List<Drink>();
    }
}
