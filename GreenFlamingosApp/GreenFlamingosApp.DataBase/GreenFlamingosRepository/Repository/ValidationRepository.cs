using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Repository
{
    public class ValidationRepository : IValidationRepository
    {
        private readonly GreenFlamingosDbContext _greenFlamingosDbContext;

        public ValidationRepository(GreenFlamingosDbContext greenFlamingosDbContext)
        {
            _greenFlamingosDbContext = greenFlamingosDbContext;
        }

        public async Task<bool> IsDrinkExistInDB(string drinkName)
        {
            return await _greenFlamingosDbContext.DbDrinks.AnyAsync(d => d.Name == drinkName);
        }
    }
}
