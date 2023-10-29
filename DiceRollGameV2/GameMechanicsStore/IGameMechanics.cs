namespace DiceRollGameV2.GameMechanicsStore
{
    public interface IGameMechanics
    {
        public bool IsCorrectGuess { get; set; }
        public int RemainingGuesses { get; set; }
        int DiceSides { get; init; }

        bool IsNotOver();
    }
}