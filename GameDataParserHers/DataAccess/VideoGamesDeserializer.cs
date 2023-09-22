using System.Text.Json;
using GameDataParserHers.Models;
using GameDataParserHers.UserInteraction;

namespace GameDataParserHers.DataAccess
{
    public class VideoGamesDeserializer : IVideoGamesDeserializer
    {
        private readonly IUserInteractor _userInteractor;

        public VideoGamesDeserializer(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public List<VideoGame>? DeserializeFrom(string? fileName, string fileContents)
        {
            try
            {
                return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
            }
            catch (JsonException ex)
            {
                _userInteractor.PrintError($"JSON is {fileName} file was not " +
                    $"in a valid format. JSON body:");
                _userInteractor.PrintError(fileContents);

                throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
            }
        }

    }
}