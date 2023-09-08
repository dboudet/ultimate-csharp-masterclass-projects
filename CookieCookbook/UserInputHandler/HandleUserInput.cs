using CookieCookbook.AppSettings;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.UserMessages;

namespace CookieCookbook.UserInputHandler
{
    public static class HandleUserInput
    {
        public static void CreateRecipe(UserSettings userSettings, Recipe recipe, Ingredient[] ingredients)
        {
            bool DoneSelectingIngredients = false;

            Array.ForEach(ingredients, v => v.PrintIngredient());


            do
            {
                DisplayMessage.PromptForSelection();
                var _selectedIngredient = Console.ReadLine();
                bool _isSelectionInt = int.TryParse(_selectedIngredient, out int _selectedIngredientAsInt);

                if (!_isSelectionInt)
                {
                    if (recipe.Count == 0)
                    {
                        DisplayMessage.FinishWithNoIngredients();
                    }
                    else
                    {
                        Console.WriteLine("Recipe added:");
                        DisplayMessage.PrintSingleRecipe(recipe);
                        recipe.StoreRecipe(userSettings);
                    }
                    DoneSelectingIngredients = true;
                    break;
                }
                else if (
                    _selectedIngredientAsInt <= 0 ||
                    _selectedIngredientAsInt > ingredients.Length)
                {
                    continue;
                }
                else
                {
                    if (_selectedIngredient is not null)
                    recipe.Add(_selectedIngredient);
                }
            }
            while (DoneSelectingIngredients == false);
        }
    }
}
