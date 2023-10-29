namespace DiceRollGameV2.UserMessages
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public string? GetUserInput() => Console.ReadLine();

        void Write(string message) => Console.WriteLine(message);
        public void DisplayIntro() => Write("Dice rolled. Guess what number it shows in 3 tries.");
        public void DisplayEnterNumber() => Write("Enter number:");
        public void DisplayInvalidInput() => Write("Incorrect input");
        public void DisplayWinner() => Write("You win! :)");
        public void DisplayWrongValidGuess() => Write("Wrong number");
        public void DisplayLoser() => Write("You lose :(");
        public void DisplayInvalidDice() => Write("Invalid number of sides provided. Using default of 6");
        public void EndGame()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}