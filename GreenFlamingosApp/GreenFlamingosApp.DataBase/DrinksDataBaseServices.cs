using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace GreenFlamingosApp.DataBase
{
    public static class GreenFlamingosDataBaseService
    {
        public static List<Drink> ReadAllDrinks()
        {
            List<Drink> DrinkList = new List<Drink>();
            var json = File.ReadAllText(@"..\..\..\..\DrinksDataBase.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            DrinkList = JsonConvert.DeserializeObject<List<Drink>>(json, settings);
            return DrinkList;
        }

        public static void WriteAllDrinks(List<Drink> drinkList)
        {
           JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };    
           var json = JsonConvert.SerializeObject(drinkList, Formatting.Indented, settings);
            File.WriteAllText(@"..\..\..\..\DrinksDataBase.json", json);
        }

        public static List<User> ReadAllUsers()
        {
            List<User> userList = new List<User>();
            var json = File.ReadAllText(@"..\..\..\..\UsersDataBase.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            userList = JsonConvert.DeserializeObject<List<User>>(json, settings);
            return userList;
        }

        public static void WriteAllUsers(List<User> userList)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(userList, Formatting.Indented, settings);
            File.WriteAllText(@"..\..\..\..\UsersDataBase.json", json);
        }

        public static List<string> ReadIngredientsDataBase()
        {
            List<string> ingredientsList = new List<string>();
            var json = File.ReadAllText(@"..\..\..\..\IngredientsDataBase.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            ingredientsList = JsonConvert.DeserializeObject<List<string>>(json, settings);
            return ingredientsList;
        }

        public static void WriteAllIngredients(List<string> ingredientsList)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(ingredientsList, Formatting.Indented, settings);
            File.WriteAllText(@"..\..\..\..\IngredientsDataBase.json", json);
        }
    }
}