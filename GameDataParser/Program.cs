using GameDataParser.UserInteractions;




const string fileName = "GameData";
const string extension = "json";
var userInteraction = new UserConsoleInteraction();


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
    public string FilePath { get; init; }
    bool IsValidFilePath(string fileName, string extension);
    bool DoesFileExist();
    string ReadFile();
    // THIS SHOULD END UP BEING A GAMES OBJECT
    // BUT DO WE KEEP THIS RETURNING A STRING?
    void HandleInvalidJson(string fileContents);

}

public class JsonFileReader : IFileReader
{
    public string FilePath { get; init; }
    public JsonFileReader(string fileName, string extension)
    {
        FilePath = $"{fileName}.{extension}";
    }
    public bool IsValidFilePath(string fileName, string extension)
    {
        return
            extension == "json" &&
            !string.IsNullOrEmpty(fileName) &&
            fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
    }

    public bool DoesFileExist()
    {
        return File.Exists(FilePath);
    }
    public string ReadFile()
    {
        string fileContents = File.ReadAllText(FilePath);
        return fileContents;
    }

    public void HandleInvalidJson(string fileContents)
    {
        throw new NotImplementedException();
    }

}




