using System.Text.Json;
using GameDataParser.ExceptionLogger;
using GameDataParser.Games;
using GameDataParser.UserInteractions;

namespace GameDataParser.FileHandler
{
    public class JsonFileReader : IFileReader
    {
        public List<Game> ReadFile(
            string filePath,
            IUserInteraction userInteraction)
        {
            var fileContents = File.ReadAllText(filePath);

            try
            {
                return JsonSerializer.Deserialize<List<Game>>(fileContents);
            }
            catch (Exception ex)
            {
                userInteraction.ShowErrorMessage(
                    $"JSON in {filePath} was not in a valid format." +
                    $"JSON body: {fileContents}");

                userInteraction.ShowMessage(
                    "Sorry! The application has experienced an unexpected error and will have to be closed.");

                throw new Exception($"{ex.Message} The file name is: {filePath}", ex);
            }
        }
    }
}
