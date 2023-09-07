using CookieCookbook.AppSettings;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.UserMessages;


// set file format to either txt or json
var _userSettings = new UserSettings(FileFormat.txt);
bool DoneSelectingIngredients = false;

if (File.Exists(_userSettings.FilePath))
{

}

Recipe recipe =
    _userSettings.SelectedFormat == FileFormat.json ? 
    new RecipeAsJson() : 
    new RecipeAsTxt();

DisplayMessage.Intro();


Ingredient[] Ingredients =
{
    new Butter(),
    new Chocolate(),
    new Cinnamon(),
    new Nuts(),
    new Sugar(),
    new WheatFlour()
};

Array.ForEach(Ingredients, v => v.PrintIngredient());


do
{
    DisplayMessage.PromptForSelection();
    int _selectedIngredientAsInt;
    var _selectedIngredient = Console.ReadLine();
    bool _isSelectionInt = int.TryParse(_selectedIngredient, out _selectedIngredientAsInt);

    if (!_isSelectionInt)
    {
        if (recipe.Count == 0)
        {
            DisplayMessage.FinishWithNoIngredients();
        }
        else
        {
            Console.WriteLine("Recipe added:");
            recipe.PrintSingleRecipe();
        }
        DoneSelectingIngredients = true;
        break;
    }
    else if (
        _selectedIngredientAsInt <= 0 ||
        _selectedIngredientAsInt > Ingredients.Length)
    {
        continue;
    }
    else
    {
        recipe.Add(Ingredients[_selectedIngredientAsInt - 1]);
        recipe.StoreRecipe();
        recipe.PrintSingleRecipe();
    }

}
while (DoneSelectingIngredients == false);


DisplayMessage.PromptForExit();
Console.ReadKey();

