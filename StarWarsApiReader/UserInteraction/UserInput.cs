namespace StarWarsApiReader.UserInteraction;

public class ConsoleUserInput : IUserInput
{
    public string? GetInput()
    {
        return Console.ReadLine();
    }
    public void EndProgramInput()
    {
        Console.ReadKey();
    }
}