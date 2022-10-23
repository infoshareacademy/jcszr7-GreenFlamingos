namespace GreenFlamingosApp.DataBase
{
    abstract class IngredientsListClass
    {
        public static List<string> AllIngredientsList { get; } = new List<string>() { "whisky", "cola", "lód", "rum", "cytryna", "pomarańcza", "limonka", "woda", "sprite",
                                                                                      "bazylia", "sok pomarańczowy", "woda gazowana" };
        public static string IngredientList()
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
            Console.WriteLine("Skłądnik dodany do ogólnej listy\n");
        }
        public void RemoveIngredientFromListByAdmin()
        {
            Console.WriteLine("Jaki składnik usunąć z ogólnej listy?");
            var ingredient = Console.ReadLine();
            if (CheckingIfListContainsIngredient(ingredient) == true)
            {
                AllIngredientsList.Add(ingredient);
                Console.WriteLine("Składnik dodany do ogólnej listy\n");
            }
            else
                Console.WriteLine("Nie ma takiego składnika na liście");
        }
        public bool CheckingIfListContainsIngredient(string ingredient)
        {
            if (AllIngredientsList.Contains(ingredient))
                return true;
            else
                return false;
        }
    }

}