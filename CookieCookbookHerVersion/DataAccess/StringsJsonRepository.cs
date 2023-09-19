using System.Text.Json;

namespace CookieCookbookHerVersion.DataAccess;

class StringsJsonRepository : StringsRepository
{
    protected override List<string> TextToStrings(string fileContents) =>
        JsonSerializer.Deserialize<List<string>>(fileContents);

    protected override string StringsToText(List<string> strings) =>
        JsonSerializer.Serialize(strings);
}
