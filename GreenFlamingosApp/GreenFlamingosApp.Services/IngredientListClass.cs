using GreenFlamingosApp.DataBase;
namespace GreenFlamingosApp.Services
{
    public class IngredientsListClass
    {
        public List<string> AllIngredientsList { get; }
        public IngredientsListClass()
        {
            AllIngredientsList = GreenFlamingosDataBaseService.ReadIngredientsDataBase();
        }
        public string IngredientList()
        {
            var listOfIngredients = "";
            foreach (var item in AllIngredientsList)
            {
                listOfIngredients = listOfIngredients + item + ", ";
            }
            listOfIngredients = listOfIngredients.Substring(0, listOfIngredients.Length - 2);
            return listOfIngredients;
        }
        public void AddIngredientToListByAdmin()
        {
            Console.WriteLine("Jaki składnik dodać do ogólnej listy?");
            var ingredient = Console.ReadLine();
            AllIngredientsList.Add(ingredient);
            GreenFlamingosDataBaseService.WriteAllIngredients(AllIngredientsList);
            Console.WriteLine("Składnik dodany do ogólnej listy\n");
        }
        public void RemoveIngredientFromListByAdmin()
        {
            Console.WriteLine("Jaki składnik usunąć z ogólnej listy?");
            var ingredient = Console.ReadLine();
            if (CheckingIfListContainsIngredient(ingredient) == true)
            {
                AllIngredientsList.Remove(ingredient);
                GreenFlamingosDataBaseService.WriteAllIngredients(AllIngredientsList);
                Console.WriteLine("Składnik usunięty z ogólnej listy\n");
            }
            else
                Console.WriteLine("Nie ma takiego składnika na liście");
        }
        public bool CheckingIfListContainsIngredient(string ingredient)
        {
            if (AllIngredientsList.Contains(ingredient,StringComparer.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }
    }

}