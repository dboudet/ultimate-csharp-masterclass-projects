using CookieCookbook.Ingredients;

namespace CookieCookbook.UserMessages
{
    public static class DisplayMessage
    {
        public static void Intro() =>
            Console.WriteLine("Create a new cookie recipe! Available Ingredients are:");
        public static void PromptForSelection() =>
            Console.WriteLine("\n" + "Add an ingredient by its ID or type anything else if finished.");
        public static void FinishWithNoIngredients() =>
            Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        public static void PromptForExit() =>
            Console.WriteLine("\n" + "Press any key to exit.");
        public static void PrintSingleRecipe(List<string> recipe)
        {
            foreach (string id in recipe)
            {
                var _ingredient = Ingredient.GetIngredientById(id);
                Console.WriteLine($"{_ingredient.Name}: {_ingredient.Instructions}");
            }
        }
        public static void PrintSavedRecipes(List<string> savedRecipes)
        {
            Console.WriteLine("Saved Recipes Found:");
            Console.WriteLine();
            for (int i = 0; i < savedRecipes.Count; i++)
            {
                var recipeAsList = savedRecipes[i].Split(',').ToList();
                Console.WriteLine($"*****{i + 1}*****");
                PrintSingleRecipe(recipeAsList);
                Console.WriteLine();
            }
        }
    }
}
