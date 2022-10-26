using GreenFlamingos.Model.Drinks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace GreenFlamingosApp.DataBase
{
    public static class DrinksDataBaseServices
    {
        public static List<Drink> ReadAll()
        {
            List<Drink> DrinkList = new List<Drink>();
            var json = File.ReadAllText(@"..\..\..\..\DrinksDataBase.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            DrinkList = JsonConvert.DeserializeObject<List<Drink>>(json, settings);
            return DrinkList;
        }

        public static void WriteAll(List<Drink> drinkList)
        {
           JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };    
           var json = JsonConvert.SerializeObject(drinkList, Formatting.Indented, settings);
            File.WriteAllText(@"..\..\..\..\DrinksDataBase.json", json);
        }
    }
}