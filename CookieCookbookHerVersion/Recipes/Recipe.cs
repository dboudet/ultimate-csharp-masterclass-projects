using CookieCookbookHerVersion.Recipes.Ingredients;

namespace CookieCookbookHerVersion.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        var steps = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}: {ingredient.Instructions}");
        }
        return string.Join(Environment.NewLine, steps);
    }
}
