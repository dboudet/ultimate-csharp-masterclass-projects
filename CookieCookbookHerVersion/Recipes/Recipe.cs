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
        return string.Join(
            Environment.NewLine,
            Ingredients.Select(ingredient => $"{ingredient.Name}: {ingredient.Instructions}"));


        //var steps = new List<string>();
        //foreach (var ingredient in Ingredients)
        //{
        //    steps.Add($"{ingredient.Name}: {ingredient.Instructions}");
        //}
        //return string.Join(Environment.NewLine, steps);
    }
}
