using CookieCookbook.AppSettings;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.UserInputHandler;
using CookieCookbook.UserMessages;


// set file format to either txt or json
var _userSettings = new UserSettings(FileFormat.txt);

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
    _userSettings.SelectedFormat == FileFormat.json ? 
    new RecipeAsJson() : 
    new RecipeAsTxt();

if (File.Exists(_userSettings.FilePath))
{
    DisplayMessage.PrintSavedRecipes(_userSettings.FilePath);
}

DisplayMessage.Intro();

HandleUserInput.CreateRecipe(recipe, _userSettings.FilePath);


DisplayMessage.PromptForExit();
Console.ReadKey();

