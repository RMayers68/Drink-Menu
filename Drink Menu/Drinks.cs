using System;

namespace Drink_Menu
{
    public class JSON
    {
        public Drinks[] drinks { get; set; }
    }

    public class Drinks
    {
        public string? strCategory { get; set; }
        public string? strDrink { get; set; }
        public string? idDrink { get; set; }
        public string? strIBA { get; set; }
        public string? strAlcoholic { get; set; }
        public string? strGlass { get; set; }
        public string? strInstructions { get; set; }
        public string? strIngredient1 { get; set; }
        public string? strIngredient2 { get; set; }
        public string? strIngredient3 { get; set; }
        public string? strIngredient4 { get; set; }
        public string? strIngredient5 { get; set; }
        public string? strIngredient6 { get; set; }
        public string? strIngredient7 { get; set; }
        public string? strIngredient8 { get; set; }
        public string? strIngredient9 { get; set; }
        public string? strIngredient10 { get; set; }
        public string? strIngredient11 { get; set; }
        public string? strIngredient12 { get; set; }
        public string? strIngredient13 { get; set; }
        public string? strIngredient14 { get; set; }
        public string? strIngredient15 { get; set; }
        public string? strMeasure1 { get; set; }
        public string? strMeasure2 { get; set; }
        public string? strMeasure3 { get; set; }
        public string? strMeasure4 { get; set; }
        public string? strMeasure5 { get; set; }
        public string? strMeasure6 { get; set; }
        public string? strMeasure7 { get; set; }
        public string? strMeasure8 { get; set; }
        public string? strMeasure9 { get; set; }
        public string? strMeasure10 { get; set; }
        public string? strMeasure11 { get; set; }
        public string? strMeasure12 { get; set; }
        public string? strMeasure13 { get; set; }
        public string? strMeasure14 { get; set; }
        public string? strMeasure15 { get; set; }
        
        public Dictionary<int, string[]> IngredientMeasures { get; set; }
            
        public void SetDictionary()
        {
            Dictionary<int, string[]> tmp = new()
            {
                { 1,new string[] { strMeasure1, strIngredient1 } },
                { 2,new string[] { strMeasure2, strIngredient2 } },
                { 3,new string[] { strMeasure3, strIngredient3 } },
                { 4,new string[] { strMeasure4, strIngredient4 } },
                { 5,new string[] { strMeasure5, strIngredient5 } },
                { 6,new string[] { strMeasure6, strIngredient6 } },
                { 7,new string[] { strMeasure7, strIngredient7 } },
                { 8,new string[] { strMeasure8, strIngredient8 } },
                { 9,new string[] { strMeasure9, strIngredient9 } },
                { 10,new string[] { strMeasure10, strIngredient10 } },
                { 11,new string[] { strMeasure11, strIngredient11 } },
                { 12,new string[] { strMeasure12, strIngredient12 } },
                { 13,new string[] { strMeasure13, strIngredient13 } },
                { 14,new string[] { strMeasure14, strIngredient14 } },
                { 15,new string[] { strMeasure15, strIngredient15 } },
            };
            IngredientMeasures = tmp;
        }               
    }
}
