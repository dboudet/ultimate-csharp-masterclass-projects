using System.Text.Json;
using CookieCookbook.DataAccess;
using CookieCookbook.Ingredients;

namespace CookieCookbook.Recipes
{
    public abstract class Recipe : List<string>, IRecipe
    {
        public abstract void StoreRecipe(string filePath);
        //public abstract void PrintSavedRecipes(string filePath);
    }

    public class RecipeAsJson : Recipe
    {
        public override void StoreRecipe(string filePath)
        {
            string _textString = string.Join(FileHandler.Separator, this);
            FileHandler.WriteToFile(filePath, _textString);
        }
        //public override void PrintSavedRecipes(string filePath)
        //{
        //    var savedRecipes = FileHandler.ReadFromFile(filePath);
        //    Console.WriteLine("Saved Recipes Found:");
        //    for (int i = 0; i < savedRecipes.Count; i++)
        //    {
        //        var recipeAsList = savedRecipes[i].Split(',').ToList();
        //        Console.WriteLine($"*****{i + 1}*****");
        //        PrintSingleRecipe(recipeAsList);
        //    }
        //}
    }
    public class RecipeAsTxt : Recipe
    {
        public override void StoreRecipe(string filePath)
        {
            var savedRecipes =
                File.Exists(filePath) ? 
                FileHandler.ReadFromFile(filePath) : 
                new List<string>();
            savedRecipes.Add(string.Join(',', this));
            FileHandler.WriteToFile(filePath, string.Join(FileHandler.Separator, savedRecipes));
        }
        //public override void PrintSavedRecipes(string filePath)
        //{
        //    var savedRecipes = FileHandler.ReadFromFile(filePath);
        //    Console.WriteLine("Saved Recipes Found:");
        //    for (int i = 0; i < savedRecipes.Count; i++)
        //    {
        //        var recipeAsList = savedRecipes[i].Split(',').ToList();
        //        Console.WriteLine($"*****{i + 1}*****");
        //        PrintSingleRecipe(recipeAsList);
        //    }
        //}
    }

}
