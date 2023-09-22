using GameDataParserHers.VideoGames;

namespace GameDataParserHers.Printer
{

    public interface IGamesPrinter
    {
        public void Print(List<VideoGame>? videoGames);
    }

}
