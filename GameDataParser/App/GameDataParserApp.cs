using GameDataParser.ExceptionLogger;
using GameDataParser.FileHandler;
using GameDataParser.Games;
using GameDataParser.UserInteractions;

namespace GameDataParser.App
{

    public class GameDataParserApp
    {
        private readonly IFileReader _fileReader;
        private readonly IUserInteraction _userInteraction;
        private readonly ILogger _logger;

        public GameDataParserApp(
            IFileReader fileReader,
            IUserInteraction userInteraction,
            ILogger logger)
        {
            _fileReader = fileReader;
            _userInteraction = userInteraction;
            _logger = logger;
        }

        public void Run()
        {
            string filePath = _userInteraction.GetFilePathFromUser();

            var games = new GamesRegister();

            var gamesFromFile = _fileReader.ReadFile(filePath, _userInteraction, _logger);

            games.Add(gamesFromFile);

            if (games.All.Any())
                _userInteraction.PrintGames(games);
            else
                _userInteraction.ShowMessage("No games are present in the input file.");
        }
    }


}
