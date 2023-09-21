using System.Text.Json;
using GameDataParser.ExceptionLogger;
using GameDataParser.FileHandler;
using GameDataParser.Games;
using GameDataParser.UserInteractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            foreach (var game in gamesFromFile)
            {
                games.All.Add(game);
            }

            _userInteraction.PrintGames(games);

            _userInteraction.EndProgram();
        }
    }


}
