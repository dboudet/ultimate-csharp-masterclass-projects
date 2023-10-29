namespace DiceRollGameV2.GameMechanicsStore
{
    public class GameMechanics : IGameMechanics
    {
        int _diceSides = 6;
        public GameMechanics(int diceSides, int maxGuesses)
        {
            DiceSides = diceSides;
            RemainingGuesses = maxGuesses > 0 ? maxGuesses : 3;
        }
        public bool IsCorrectGuess { get; set; } = false;
        public int RemainingGuesses { get; set; } = 3;
        public int DiceSides
        {
            get => _diceSides;
            init => _diceSides = value > 0 ? value : 6;
        }
        public bool IsNotOver() => RemainingGuesses > 0 && !IsCorrectGuess;
    }
}