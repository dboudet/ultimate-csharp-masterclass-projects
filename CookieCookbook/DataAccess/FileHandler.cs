using System.Text.Json;
using CookieCookbook.AppSettings;

namespace CookieCookbook.DataAccess
{
    public static class FileHandler
    {
        public static readonly string Separator = Environment.NewLine;

        public static List<string> ReadFromFile(UserSettings userSettings)
        {
            return
                userSettings.SelectedFormat == FileFormat.json
                ? ReadFromJsonFile(userSettings.FilePath)
                : ReadFromTextFile(userSettings.FilePath);
        }

        static List<string> ReadFromJsonFile(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<string>>(fileContents) ?? new List<string>();
        }
        static List<string> ReadFromTextFile(string filePath)
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