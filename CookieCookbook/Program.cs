using CookieCookbook.AppSettings;
using CookieCookbook.DataAccess;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.UserInputHandler;
using CookieCookbook.UserMessages;


// set file format to either txt or json
var userSettings = new UserSettings(FileFormat.txt);

Ingredient[] Ingredients =
{
    new Butter(),
    new Chocolate(),
    new Cinnamon(),
    new Nuts(),
    new Sugar(),
    new WheatFlour()
};

Recipe recipe =
    userSettings.SelectedFormat == FileFormat.json ? 
    new RecipeAsJson() : 
    new RecipeAsTxt();

if (File.Exists(userSettings.FilePath))
{
    var _savedRecipes = FileHandler.ReadFromFile(userSettings);
    DisplayMessage.PrintSavedRecipes(_savedRecipes);
}

DisplayMessage.Intro();

HandleUserInput.CreateRecipe(userSettings, recipe, Ingredients);


DisplayMessage.PromptForExit();
Console.ReadKey();

