using CookieCookbook.Recipes;

namespace CookieCookbook.UserMessages
{
    public static class DisplayMessage
    {
        public static void PrintSingleRecipe(Recipe recipe)
        {
            Console.WriteLine(recipe);
        }
        public static void Intro() =>
            Console.WriteLine("Create a new cookie recipe! Available Ingredients are:");
        public static void PromptForSelection() =>
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
        public static void FinishWithNoIngredients() =>
            Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        public static void PromptForExit() =>
            Console.WriteLine("Press any key to exit.");
        //public static void () =>
        //    Console.WriteLine("");
    }
}
