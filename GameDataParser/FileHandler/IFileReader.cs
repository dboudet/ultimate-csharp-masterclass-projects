using GameDataParser.ExceptionLogger;
using GameDataParser.Games;
using GameDataParser.UserInteractions;

namespace GameDataParser.FileHandler
{
    public interface IFileReader
    {
        public List<Game> ReadFile(
            string filePath,
            IUserInteraction userInteraction,
            ILogger logger);
    }
}
