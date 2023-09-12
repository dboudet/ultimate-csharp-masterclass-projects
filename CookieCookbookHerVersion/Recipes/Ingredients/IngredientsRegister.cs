namespace CookieCookbookHerVersion.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
{
    new Butter(),
    new Chocolate(),
    new Cinnamon(),
    new Walnuts(),
    new Sugar(),
    new WheatFlour(),
    new Pecans()
};

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }
        return null;
    }
}
