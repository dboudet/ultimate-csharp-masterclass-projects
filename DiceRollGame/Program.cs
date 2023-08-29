

int numberOfGuesses = 0;
bool correctGuess = false;

int randomNumber = new RandomNumber().RollDice();
var validateUserInput = new ValidateUserInput();
Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

do
{
    string? userInput = Console.ReadLine();
    // validate guess is [valid?] number
    if (!validateUserInput.IsNumber(userInput))
    {
        Console.WriteLine("Incorrect Input");
        continue;
    }
    // input is valid number; check against randomNumber
    else if (validateUserInput.userGuessInt == randomNumber)
    {
        correctGuess = true;
        Console.WriteLine("You win! :)");
    }
    else
    {
        Console.WriteLine("Wrong number");
        numberOfGuesses++;
    }
}
while (numberOfGuesses < 3 && correctGuess == false);

if (correctGuess == false) Console.WriteLine("You lose :(");
Console.ReadKey();

