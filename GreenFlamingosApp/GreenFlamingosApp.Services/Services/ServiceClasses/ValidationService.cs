using GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces;
using GreenFlamingosApp.Services.Services.Interfaces;

namespace GreenFlamingosApp.Services.Services.ServiceClasses
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationRepository _validationRepository;

        public ValidationService(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        public async Task<bool> IsDrinkExistInDB(string drinkName)
        {
            return await _validationRepository.IsDrinkExistInDB(drinkName);
        }
    }
}
