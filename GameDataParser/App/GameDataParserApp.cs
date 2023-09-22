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

        public GameDataParserApp(
            IFileReader fileReader,
            IUserInteraction userInteraction)
        {
            _fileReader = fileReader;
            _userInteraction = userInteraction;
        }

        public void Run()
        {
            string filePath = _userInteraction.GetFilePathFromUser();

            var games = new GamesRegister();

            var gamesFromFile = _fileReader.ReadFile(filePath, _userInteraction);

            games.Add(gamesFromFile);

            if (games.All.Any())
                _userInteraction.PrintGames(games);
            else
                _userInteraction.ShowMessage("No games are present in the input file.");
        }
    }


}
