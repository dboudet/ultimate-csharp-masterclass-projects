using System.Text.Json;
using CookieCookbook.AppSettings;
using CookieCookbook.DataAccess;

namespace CookieCookbook.Recipes
{
    public abstract class Recipe : List<string>, IRecipe
    {
        public abstract void StoreRecipe(UserSettings userSettings);
        protected List<string> GetSavedRecipes(UserSettings userSettings)
        {
            return File.Exists(userSettings.FilePath) ?
                FileHandler.ReadFromFile(userSettings) :
                new List<string>();
        }
    }

    public class RecipeAsJson : Recipe
    {
        public override void StoreRecipe(UserSettings userSettings)
        {
            var savedRecipes = new List<string>();
            if (File.Exists(userSettings.FilePath))
            {
                savedRecipes = FileHandler.ReadFromFile(userSettings);
            }

            var newRecipeAsString = string.Join(',', this);
            savedRecipes.Add(newRecipeAsString);
            string _jsonString = JsonSerializer.Serialize(savedRecipes);
            
            FileHandler.WriteToFile(userSettings.FilePath, _jsonString);
        }
    }
    public class RecipeAsTxt : Recipe
    {
        public override void StoreRecipe(UserSettings userSettings)
        {
            var savedRecipes =
                File.Exists(userSettings.FilePath) ? 
                FileHandler.ReadFromFile(userSettings) : 
                new List<string>();
            savedRecipes.Add(string.Join(',', this));
            FileHandler.WriteToFile(userSettings.FilePath, string.Join(FileHandler.Separator, savedRecipes));
        }
    }

}
