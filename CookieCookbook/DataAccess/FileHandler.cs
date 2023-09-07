using CookieCookbook.AppSettings;
using CookieCookbook.Recipes;

namespace CookieCookbook.DataAccess
{
    public static class FileHandler
    {
        static readonly string _separator = Environment.NewLine;

        public static List<string> ReadFromFile(string filePath)
        {
            //string _filePath = format == FileFormat.Json ? _jsonFilePath : _textFilePath;
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(_separator).ToList();
        }

        public static void WriteToFile(string filePath, Recipe recipe)
        {
            //string _filePath = format == FileFormat.Json ? _jsonFilePath : _textFilePath;
            File.WriteAllText(
                filePath,
                string.Join(_separator, recipe));
        }
    }
}