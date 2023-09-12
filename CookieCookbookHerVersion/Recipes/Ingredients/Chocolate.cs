namespace CookieCookbookHerVersion.Recipes.Ingredients;

public class Chocolate : Ingredient
{
    public override int Id => 2;
    public override string Name => "Chocolate";
    public override string Instructions => $"Melt in double boiler. {base.Instructions}";
}
