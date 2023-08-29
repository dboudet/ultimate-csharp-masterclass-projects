public class ValidateUserInput
{
    public int userGuessInt;
    public bool IsNumber(string? userInput)
    {
        return int.TryParse(userInput, out userGuessInt);
    }
}