﻿using ConsoleTableExt;
using System.Text.Json;

namespace Drink_Menu
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string stackSelection;
            bool closeProgram = false;
            while (!closeProgram)                                                     //MAIN MENU
            {
                Console.Clear();
                List<string> list = await ProcessJSONRequest("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
                Console.WriteLine("Please enter a Category you would like to choose (type exactly as shown) or input Exit to terminate:");
                stackSelection = TextCheck(list);
                bool goBack = false;
                string drinkChoice;
                if (stackSelection == "Exit")
                {
                    Console.WriteLine("Goodbye!");
                    Console.ReadKey();
                    closeProgram = true;
                }
                 else while (!goBack)
                {
                    list.Clear();
                    Console.Clear();
                    list = await ProcessJSONRequest($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={stackSelection}");
                    Console.WriteLine("Please enter the drink you would like to know more about or enter \"Go Back\":");
                    drinkChoice = TextCheck(list);
                    if (drinkChoice == "Go Back")
                        goBack = true;
                    else
                    {
                        Console.Clear();
                        await ProcessJSONRequest($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drinkChoice}");
                        Console.WriteLine("Press any key to return to drink list...");
                        Console.ReadKey();
                    }                   
                }
            }
        }



        // Data Validation
        public static string TextCheck(List<string> list)
        {
            while (true)
            {
                string a = Console.ReadLine();
                if (a == "Go Back" || a == "Exit")
                    return a;
                foreach (var category in list)
                    if (category == a)
                        return a;
                Console.WriteLine("Invalid input, please enter the correct name: ");
            }
        }

        //JSON Object Handling
        private static async Task<List<string>> ProcessJSONRequest(string URL)
        {
            var streamTask = client.GetStreamAsync(URL);
            var choices = await JsonSerializer.DeserializeAsync<JSON>(await streamTask);
            List<string> list = new();
            if (URL.Contains("c=list"))                                 // Category
            {
                foreach (var x in choices.drinks)
                    list.Add(x.strCategory);
                ConsoleTableBuilder.From(list).WithTitle("Category Menu").ExportAndWriteLine(TableAligntment.Center);
            }
            else if (URL.Contains("s="))                                // Drink
            {
                foreach(var x in choices.drinks)
                {
                    list.Add($"Name: {x.strDrink}");
                    list.Add($"{x.strAlcoholic}");
                    list.Add($"Glass: {x.strGlass}");
                    list.Add($"Ingredient 1: {x.strMeasure1} {x.strIngredient1}");
                }
                ConsoleTableBuilder.From(list).ExportAndWriteLine();
            }
            else                                                        // Drink List
            {
                foreach (var x in choices.drinks)
                    list.Add(x.strDrink);
                ConsoleTableBuilder.From(list).WithTitle("Category Menu").ExportAndWriteLine(TableAligntment.Center);
            }
            return list;
        }
    }    
}