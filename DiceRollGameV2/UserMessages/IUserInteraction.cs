namespace DiceRollGameV2.UserMessages
{
    public interface IUserInteraction
    {
        void DisplayEnterNumber();
        void DisplayIntro();
        void DisplayInvalidInput();
        void DisplayInvalidDice();
        void DisplayLoser();
        void DisplayWinner();
        void DisplayWrongValidGuess();

        public string? GetUserInput();
        void EndGame();
    }
}