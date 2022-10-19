using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services
{
    public class DrinksMenu
    {
        DrinkBookService drinkBook = new DrinkBookService();

        public void DrinkService()
        {
            int userInput;   
            do 
            {
                DefaultMenu.DrinkOptionsForAdmin();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch(userInput)
                    {
                        case 1:
                            var newAlcoDrink = new AlcoDrink();
                            drinkBook.CreateAlcoDrink(newAlcoDrink);

                            //Validation of drink name - if in DrinkBookService exists drink with the same name as user set - do not add.
                            var drinkToAdd = drinkBook.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newAlcoDrink.Name.ToUpper()));
                            if (drinkToAdd != null)
                            {
                                Console.WriteLine("Drink o podanej nazwie istnieje");
                                Console.ReadKey();
                            }
                            else
                            {
                                drinkToAdd = new AlcoDrink(newAlcoDrink.Name,
                                                           newAlcoDrink.MainIngredient,
                                                           newAlcoDrink.Capacity,
                                                           newAlcoDrink.Ingredient1,
                                                           newAlcoDrink.Ingredient2,
                                                           newAlcoDrink.Ingredient3);
                                drinkBook.AddDrink(drinkToAdd);
                                Console.WriteLine("Brawo, Pomyslnie stworzyłeś drinka !");
                                Console.ReadKey();
                            }

                            Console.ReadKey();
                            break;
                        case 2:
                            drinkBook.ShowAllDrinks();
                            Console.ReadKey();
                            break;
                        case 3:
                            drinkBook.RemoveDrink();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Znajdz Drinka");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Edycja Drinka");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("Bye");
                            break;
                    }
                }
                }while (userInput!=6);
        }
        
    }
}
