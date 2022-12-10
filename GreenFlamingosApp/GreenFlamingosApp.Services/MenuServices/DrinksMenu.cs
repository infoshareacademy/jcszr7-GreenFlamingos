using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services.MenuServices
{
    public class DrinksMenu
    {
        private DrinkBookService _drinkBook = new DrinkBookService();
        private UnloggedMenu _unlogged = new UnloggedMenu();
        private LoggedUserMenu _logged = new LoggedUserMenu();
        private AdminMenu _admin = new AdminMenu();
        public void DrinkService(Drink newDrink,User user,int menuIndex)
        {
            if(user.UserLevel == UserLevel.unlogged)
            {
                _unlogged.UnloggedMenuService(menuIndex,user,newDrink,_drinkBook);
            }
            else if(user.UserLevel == UserLevel.logged)
            {
                _logged.UserMenuService(menuIndex, newDrink, user,_drinkBook);
            }
            else
            {
                _admin.AdminMenuService(menuIndex, newDrink, user, _drinkBook);
            }
        }

    }
}
