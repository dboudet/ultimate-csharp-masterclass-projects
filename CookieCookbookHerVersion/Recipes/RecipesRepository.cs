using CookieCookbookHerVersion.DataAccess;
using CookieCookbookHerVersion.Recipes.Ingredients;

namespace CookieCookbookHerVersion.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister
    )
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        return _stringsRepository.Read(filePath)
            .Select(RecipeFromString)
            .ToList();



        //var recipesFromFile = _stringsRepository.Read(filePath);
        //var recipes = new List<Recipe>();

        //foreach (var recipeFromFile in recipesFromFile)
        //{
        //    var recipe = RecipeFromString(recipeFromFile);
        //    recipes.Add(recipe);
        //}
        //return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        return new Recipe(recipeFromFile.Split(Separator)
            .Select(id => _ingredientsRegister.GetById(int.Parse(id)))
            .ToList());

        // her LINQ version:
        //var ingredients = recipeFromFile.Split(Separator)
        //    .Select(int.Parse)
        //    .Select(_ingredientsRegister.GetById);
        //return new Recipe(ingredients);


        //var textualIds = recipeFromFile.Split(Separator);
        //var ingredients = new List<Ingredient>();

        //foreach (var textualId in textualIds)
        //{
        //    var id = int.Parse(textualId);
        //    var ingredient = _ingredientsRegister.GetById(id);
        //    ingredients.Add(ingredient);
        //}
        //return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        Func<IEnumerable<Ingredient>, string> IngredientsFromSingleRecipeAsString =
            ingredients => string.Join(Separator, ingredients.Select(v => v.Id));

        var recipesAsStrings = allRecipes
            .Select(recipe => recipe.Ingredients)
            .Select(IngredientsFromSingleRecipeAsString)
            .ToList();


        // her LINQ version:
        //var recipesAsStrings = allRecipes
        //    .Select(recipe => string.Join(
        //            Separator,
        //            recipe.Ingredients.Select(ingredient => ingredient.Id)))
        //    .ToList();


        //var recipesAsStrings = new List<string>();
        //foreach (var recipe in allRecipes)
        //{


        //    //var allIds = new List<int>();
        //    //foreach (var ingredient in recipe.Ingredients)
        //    //{
        //    //    allIds.Add(ingredient.Id);
        //    //}
        //    recipesAsStrings.Add(string.Join(Separator, allIds));
        //}



        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
