
bool isCorrectGuess = false;
int remainingGuesses = 3;

// can change dice sides; defaults to 6 in Constructor
var diceRoll = new Dice().Roll();
DisplayMessage.Intro();


while (remainingGuesses > 0 && !isCorrectGuess)
{
    var userInput = new UserInput(Console.ReadLine());

    if (!userInput.IsInteger)
    {
        DisplayMessage.Invalid();
    }
    else if (userInput.InputAsInt == diceRoll)
    {
        DisplayMessage.Winner();
        isCorrectGuess = true;
        break;
    }
    else
    {
        DisplayMessage.WrongValidGuess();
        remainingGuesses--;
    }
    
    if (remainingGuesses > 0) DisplayMessage.EnterNumber();
}

if (!isCorrectGuess) DisplayMessage.Loser();

Console.ReadKey();
