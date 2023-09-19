namespace CookieCookbookHerVersion.Recipes.Ingredients;

public class WheatFlour : Ingredient
{
    public override int Id => 6;
    public override string Name => "Wheat Flour";
    public override string Instructions => $"Sieve. {base.Instructions}";
}
