using GameDataParserHers.Models;

namespace GameDataParserHers.DataAccess
{
    public interface IVideoGamesDeserializer
    {
        List<VideoGame>? DeserializeFrom(string? fileName, string fileContents);

    }
}