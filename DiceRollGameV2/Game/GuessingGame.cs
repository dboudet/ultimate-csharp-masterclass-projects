using DiceRollGameV2.UserCommunication;

namespace DiceRollGameV2.Game
{
    public partial class GuessingGame
    {
        public bool IsCorrectGuess = false;
        public int RemainingGuesses;
        public int MaxGuesses { init => RemainingGuesses = value > 0 ? value : 3; }
        public required Dice _dice;
        
        public Result Play()
        {
            var diceRoll = _dice.Roll();
            DisplayMessage.Intro();
            {
                while (RemainingGuesses > 0)
                {
                    var userInput = new UserInput(Console.ReadLine());

                    if (!userInput.IsInteger)
                    {
                        DisplayMessage.Invalid();
                        continue;
                    }
                    else if (userInput.InputAsInt == diceRoll)
                    {
                        return Result.Victory;
                    }
                    else
                    {
                        DisplayMessage.WrongValidGuess();
                        RemainingGuesses--;
                    }

                    if (RemainingGuesses > 0) DisplayMessage.EnterNumber();
                }

                return Result.Loss;
            }
        }
    }
}