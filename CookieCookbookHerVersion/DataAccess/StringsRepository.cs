namespace CookieCookbookHerVersion.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    protected abstract List<string> TextToStrings(string fileContents);
    protected abstract string StringsToText(List<string> strings);
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }
        else return new List<string>();
    }
    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }
}
