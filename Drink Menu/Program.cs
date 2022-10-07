using ConsoleTableExt;
using Drink_Menu;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Flashcards
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
            bool closeProgram = false;
            while (!closeProgram)                                                     //MAIN MENU
            {
                string stackSelection = "";
                string[] categories = { "Categories Menu", "Ordinary Drink", "Cocktail", "Milk/Float/Shake", "Other/Unknown", "Cocoa", "Shot", "Coffee/Tea", "Homemade Liqeur", "Punch,Party Drink", "Beer", "Soft Drink/Soda" };
                List<string> list = new(categories);
                ConsoleTableBuilder.From(list).ExportAndWriteLine();
                stackSelection = DataValidation.EmptyStringCheck();
                switch (stackSelection)
                {
                    default:
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        closeProgram = true;
                        break;
                }
            }
                   
        }

        // Menu UI Methods
        public static string Tab(int i)
        {
            string tab = "";
            for (int j = 0; j < i; j++)
                tab += "\t";
            return tab;
        }

        public static string MenuLine()
        {
            string a = $"{Tab(5)}********************************";
            return a;
        }
        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        private static async Task ProcessRepositories()
        {

            /*client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            */

            var streamTask = client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            var categories = await JsonSerializer.DeserializeAsync<Categories>(await streamTask);


            /*var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);System.Text.Json.JsonException: 'The JSON value could not be converted to System.Collections.Generic.List`1[Drink_Menu.Repository]. Path: $ | LineNumber: 0 | BytePositionInLine: 1.'
            */

            Console.WriteLine(categories.strCategory);
        }
    }
}