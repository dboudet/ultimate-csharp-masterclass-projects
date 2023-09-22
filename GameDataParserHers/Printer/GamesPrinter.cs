using GameDataParserHers.UserInteractions;
using GameDataParserHers.VideoGames;

namespace GameDataParserHers.Printer
{
    public class GamesPrinter : IGamesPrinter
    {
        private readonly IUserInteractor _userInteractor;

        public GamesPrinter(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Print(List<VideoGame>? videoGames)
        {
            if (videoGames.Any())
            {
                _userInteractor.PrintMessage(
                    Environment.NewLine + "Loaded games are:");
                foreach (var game in videoGames)
                {
                    _userInteractor.PrintMessage(game.ToString());
                }
            }
            else
            {
                _userInteractor.PrintMessage("No games are present in the input file.");
            }
        }
    }

}
