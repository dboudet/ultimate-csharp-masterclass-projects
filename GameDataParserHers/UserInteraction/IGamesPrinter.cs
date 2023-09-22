using GameDataParserHers.Models;

namespace GameDataParserHers.UserInteraction
{

    public interface IGamesPrinter
    {
        public void Print(List<VideoGame>? videoGames);
    }

}
