public class UserInput
{
    public bool IsInteger { get; private set; }
    public readonly int InputAsInt;

    public UserInput(string? userInput)
    {
        IsInteger = int.TryParse(userInput, out InputAsInt);
    }
}
