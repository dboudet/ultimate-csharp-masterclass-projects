using CookieCookbookHerVersion.App;
using CookieCookbookHerVersion.Recipes;
using CookieCookbookHerVersion.Recipes.Ingredients;
using CookieCookbookHerVersion.DataAccess;
using CookieCookbookHerVersion.FileAccess;

const FileFormat Format = FileFormat.Json;
const string FileName = "recipes";
var fileMetaData = new FileMetadata(FileName, Format);

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();


var ingredientsRegister = new IngredientsRegister();

var cookieRecipesApp = new CookieRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));
cookieRecipesApp.Run(fileMetaData.ToPath());
