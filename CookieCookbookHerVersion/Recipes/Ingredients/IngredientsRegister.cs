namespace CookieCookbookHerVersion.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } =
        new List<Ingredient>
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
        //bool containsDuplicateIds = All.DistinctBy(x => x.Id).Count() != All.Count();

        var allIngredientsWithIds = All
            .Where(x => x.Id == id);

        if (allIngredientsWithIds.Count() > 1)
        {
            throw new InvalidOperationException(
                $"More than one ingredient with id {id} was found.");
        }
        return allIngredientsWithIds.FirstOrDefault();


        //foreach (var ingredient in All)
        //{
        //    if (ingredient.Id == id)
        //    {
        //        return ingredient;
        //    }
        //}
        //return null;
    }
}
