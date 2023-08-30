
var game = new GameMechanics
{
    MaxGuesses = 3,
    DiceSides = 6
};

var diceRoll = new Dice(game.DiceSides).Roll();
DisplayMessage.Intro();


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

Console.ReadKey();
