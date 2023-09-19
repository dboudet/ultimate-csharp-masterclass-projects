


public bool IsInputValid = false;

while (!IsInputValid)
{
    Console.WriteLine("Enter the name of the file you want to read:");

    string? input = Console.ReadLine();

    bool isInputNull = true;
    bool isInputEmpty = true;

    public bool ValidateInput(string? input)
    {

    }

}

public interface IFileReader
{
    string ReadFile(string path);
    void HandleInvalidJson(string fileContents);

}

public class JsonFileReader : IFileReader
{
    public string ReadFile(string path)
    {
        string fileContents = File.ReadAllText(path);
        return fileContents;
    }

    public void HandleInvalidJson(string fileContents)
    {
        throw new NotImplementedException();
    }
}



Console.WriteLine("Press any key to close.");
Console.ReadKey();

public interface IUserMessages
{
    void ShowMessage(string message);
    void EndProgram();
    void PromptForInput();

}