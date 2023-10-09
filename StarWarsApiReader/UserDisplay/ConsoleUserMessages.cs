namespace StarWarsApiReader.UserDisplay;

public class ConsoleUserMessages : IUserMessages
{
    public void DisplayProperties()
    {
        Console.WriteLine();
        Console.WriteLine("The statistics of which property would you like to see?");
        Console.WriteLine("population");
        Console.WriteLine("diameter");
        Console.WriteLine("surface water");
    }
    public void DisplayInvalidInputResponse()
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
    public void DisplayResults(string userInput, Dictionary<string, KeyValuePair<string, int>> minAndMaxByProperty)
    {
        Console.WriteLine(
            $"Max {userInput} is {minAndMaxByProperty["Max"].Value} (planet: {minAndMaxByProperty["Max"].Key})");
        Console.WriteLine(
            $"Min {userInput} is {minAndMaxByProperty["Min"].Value} (planet: {minAndMaxByProperty["Min"].Key})");

    }
    public void DisplayErrorMessage(Exception ex)
    {
        Console.WriteLine("Sorry, an error has occurred:", ex.Message);
    }
    public void EndProgram()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}
