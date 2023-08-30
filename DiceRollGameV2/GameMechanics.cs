public class GameMechanics
{
    public bool IsCorrectGuess = false;
    public int RemainingGuesses;
    public int DiceSides { get; init; } = 6;
    public int MaxGuesses { init => RemainingGuesses = value; }
    public bool IsNotOver() => RemainingGuesses > 0 && !IsCorrectGuess;
}
