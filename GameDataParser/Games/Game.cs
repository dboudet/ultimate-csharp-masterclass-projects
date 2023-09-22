namespace GameDataParser.Games
{
    public class Game
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Rating { get; set; }

        public override string ToString() =>
            $"{Title}, released in {ReleaseYear}, rating: {Rating}";
    }

}
