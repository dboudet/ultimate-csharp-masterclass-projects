using System.Text.Json;
using CookieCookbook.DataAccess;
using CookieCookbook.Ingredients;

namespace CookieCookbook.Recipes
{
    public abstract class Recipe : List<Ingredient>, IRecipe
    {
        public abstract void StoreRecipe();
        public void PrintSingleRecipe()
        {
            foreach (var item in this)
            {
                Console.WriteLine($"{item.Name}: {item.Instructions}");
            }
        }
        public void PrintSavedRecipes(string filePath)
        {
            var savedRecipes = FileHandler.ReadFromFile(filePath);
            Console.WriteLine("Saved Recipes Found:");
            foreach (var item in savedRecipes)
            {
                PrintSingleRecipe();
            }
        }
    }

    public class RecipeAsJson : Recipe
    {
        //string? _asJson;
        public override void StoreRecipe()
        {
            //_asText = JsonSerializer.Serialize(this);
            //Console.WriteLine(_asJson);
            Console.WriteLine("store recipe in file");
        }
    }
    public class RecipeAsTxt : Recipe
    {
        public override void StoreRecipe()
        {
            //_asText = JsonSerializer.Serialize(this);
            //Console.WriteLine(_asJson);
            Console.WriteLine("store recipe in file");
        }
    }

}
