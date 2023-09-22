using GameDataParser.UserInteractions;

namespace GameDataParser.Games
{
    public class GamesRegister
    {
        public List<Game> All { get; } = new List<Game>();
        public void Add(List<Game> gamesFromFile)
        {
            foreach (var game in gamesFromFile)
            {
                All.Add(game);
            }
        }

    }

}
