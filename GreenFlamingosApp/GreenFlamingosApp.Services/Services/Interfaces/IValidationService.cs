using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IValidationService
    {
        Task<bool> IsDrinkExistInDB(string drinkName);
    }
}
