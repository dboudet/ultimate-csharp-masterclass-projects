namespace StarWarsApiReader.UserDisplay
{
    public interface IUserMessages
    {
        void DisplayErrorMessage(Exception ex);
        void DisplayInvalidInputResponse();
        void DisplayProperties();
        void DisplayResults(string userInput, Dictionary<string, KeyValuePair<string, int>> minAndMaxByProperty);
        void EndProgram();
    }
}