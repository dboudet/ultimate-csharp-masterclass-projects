using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;
using CookieCookbook.UserMessages;

namespace CookieCookbook.UserInputHandler
{
    public static class HandleUserInput
    {
        public static void CreateRecipe(Recipe recipe, string filePath)
        {
            bool DoneSelectingIngredients = false;

            Ingredient.All.ForEach(v => v.PrintIngredient());


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
                        recipe.StoreRecipe(filePath);
                    }
                    DoneSelectingIngredients = true;
                    break;
                }
                else if (
                    _selectedIngredientAsInt <= 0 ||
                    _selectedIngredientAsInt > Ingredient.All.Count)
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
