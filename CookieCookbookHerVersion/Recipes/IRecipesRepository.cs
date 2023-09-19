namespace CookieCookbookHerVersion.Recipes;

public interface IRecipesRepository
{
    public List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}
