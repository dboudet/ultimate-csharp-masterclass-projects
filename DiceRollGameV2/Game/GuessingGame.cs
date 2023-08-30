using DiceRollGameV2.UserMessages;

namespace DiceRollGameV2.Game
{
    public class GuessingGame
    {
        public static void Play(GameMechanics game)
        {
            var diceRoll = new Dice(game.DiceSides).Roll();

            while (game.IsNotOver())
            {
                var userInput = new UserInput(Console.ReadLine());

                if (!userInput.IsInteger)
                {
                    DisplayMessage.Invalid();
                }
                else if (userInput.InputAsInt == diceRoll)
                {
                    DisplayMessage.Winner();
                    game.IsCorrectGuess = true;
                    break;
                }
                else
                {
                    DisplayMessage.WrongValidGuess();
                    game.RemainingGuesses--;
                }

                if (game.RemainingGuesses > 0) DisplayMessage.EnterNumber();
            }

            if (!game.IsCorrectGuess) DisplayMessage.Loser();

        }
    }
}
