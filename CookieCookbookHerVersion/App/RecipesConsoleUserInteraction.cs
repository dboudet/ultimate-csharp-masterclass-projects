using System.Diagnostics.Metrics;
using CookieCookbookHerVersion.Recipes;
using CookieCookbookHerVersion.Recipes.Ingredients;

namespace CookieCookbookHerVersion.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Any())
        {
            Console.WriteLine("Saved recipes found:");

            var allRecipesAsString = allRecipes
            .Select((recipe, index) =>
$@"*****{index + 1}*****
{recipe}
"
);
            Console.WriteLine(string.Join(Environment.NewLine, allRecipesAsString));

            //int counter = 1;
            //foreach (var recipe in allRecipes)
            //{
            //    Console.WriteLine($"*****{counter}*****");
            //    Console.WriteLine(recipe);
            //    Console.WriteLine();
            //    ++counter;
            //}
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe!");
        Console.WriteLine("Available ingredients are:");


        Console.WriteLine(string.Join(Environment.NewLine, _ingredientsRegister.All));


        //foreach (var ingredient in _ingredientsRegister.All)
        //{
        //    Console.WriteLine(ingredient);
        //}
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool doneSelectingIngredients = false;
        var newIngredients = new List<Ingredient>();

        while (!doneSelectingIngredients)
        {
            Console.WriteLine(
                "Add an ingredient by its ID, " + "or type anything else if finished."
            );

            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    newIngredients.Add(selectedIngredient);
                }
            }
            else
            {
                doneSelectingIngredients = true;
            }
        }
        return newIngredients;
    }
}
