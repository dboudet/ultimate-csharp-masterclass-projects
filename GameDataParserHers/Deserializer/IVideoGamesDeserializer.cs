using GameDataParserHers.VideoGames;

namespace GameDataParserHers.Deserializer
{
    public interface IVideoGamesDeserializer
    {
        List<VideoGame>? DeserializeFrom(string? fileName, string fileContents);

    }
}