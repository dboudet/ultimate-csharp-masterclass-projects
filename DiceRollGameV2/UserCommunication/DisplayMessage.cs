
namespace DiceRollGameV2.UserCommunication
{
    public static class DisplayMessage
    {
        static void Write(string message) => Console.WriteLine(message);
        public static void Intro() => Write("Dice rolled. Guess what number it shows in 3 tries.");
        public static void EnterNumber() => Write("Enter number:");
        public static void Invalid() => Write("Incorrect input");
        public static void WrongValidGuess() => Write("Wrong number");

        public static void GameResult(string result)
        {
            if (result == "Victory")
            {
                Write("You win! :)");
            }
            else
            {
                Write("You lose :(");
            }
        }
    }
}