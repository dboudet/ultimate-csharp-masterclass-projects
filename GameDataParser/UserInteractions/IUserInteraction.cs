namespace GameDataParser.UserInteractions
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        string? ReadUserInput();
        void EndProgram();

    }
}
