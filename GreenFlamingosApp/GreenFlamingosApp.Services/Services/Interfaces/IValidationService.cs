using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IValidationService
    {
        Task<bool> IsDrinkExistInDB(string drinkName);
    }
}
