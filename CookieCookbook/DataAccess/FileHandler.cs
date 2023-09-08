using System.Text.Json;
using CookieCookbook.AppSettings;
using CookieCookbook.Recipes;

namespace CookieCookbook.DataAccess
{
    public static class FileHandler
    {
        public static readonly string Separator = Environment.NewLine;

        public static List<string> ReadFromFile(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(Separator).ToList();
        }

        public static void WriteToFile(string filePath, string fileContents)
        {
            File.WriteAllText(
                filePath,
                fileContents);
        }
    }
}