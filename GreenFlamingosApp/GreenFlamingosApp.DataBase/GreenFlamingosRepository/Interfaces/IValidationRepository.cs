using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces
{
    public interface IValidationRepository
    {
        public Task<bool> IsDrinkExistInDB(string drinkName);
    }
}
