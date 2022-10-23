using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services.MenuServices
{
    public class DrinksMenu
    {
        private DrinkBookService drinkBook = new DrinkBookService();
        private UsersMenu unlogged = new UsersMenu();
        private LoggedUserMenu logged = new LoggedUserMenu();
        public void DrinkService(Drink newDrink,User user,int menuIndex)
        {
            var userInput = 0;

                    if(user.UserLevel == UserLevel.unlogged)
                    {
                        unlogged.UnloggedMenuService(menuIndex,user,newDrink,drinkBook);
                    }
                    else if(user.UserLevel == UserLevel.logged)
                    {
                        logged.UserMenuService(menuIndex, newDrink, user,drinkBook);
                    }
                    else
                    {
                        ////////TUTAJ MENU DLA ADMINA///////////////
                    }
        }

    }
}
