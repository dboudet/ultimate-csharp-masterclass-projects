using DiceRollGameV2.DiceStore;
using DiceRollGameV2.GameMechanicsStore;
using DiceRollGameV2.UserMessages;

namespace DiceRollGameV2.Game
{
    public class GuessingGame
    {
        IDice Dice { get; }
        IGameMechanics GameMechanics { get; }
        IUserInteraction UserInteraction { get; }


        public GuessingGame(IDice dice, IGameMechanics gameMechanics, IUserInteraction userInteraction)
        {
            Dice = dice;
            GameMechanics = gameMechanics;
            UserInteraction = userInteraction;
        }

        public void Play()
        {
            UserInteraction.DisplayIntro();
            var diceRoll = Dice.Roll();

            while (GameMechanics.IsNotOver())
            {
                var userInput = UserInteraction.GetUserInput();

                bool isInputInteger = int.TryParse(userInput, out int inputAsInteger);

                if (!isInputInteger)
                {
                    UserInteraction.DisplayInvalidInput();
                }
                else if (inputAsInteger == diceRoll)
                {
                    UserInteraction.DisplayWinner();
                    GameMechanics.IsCorrectGuess = true;
                    break;
                }
                else
                {
                    UserInteraction.DisplayWrongValidGuess();
                    GameMechanics.RemainingGuesses--;
                }

                if (GameMechanics.RemainingGuesses > 0) UserInteraction.DisplayEnterNumber();
            }

            if (!GameMechanics.IsCorrectGuess) UserInteraction.DisplayLoser();

        }
    }
}
