namespace GameDataParserHers.UserInteraction
{
    public interface IUserInteractor
    {
        public string? ReadValidFilePath();
        void PrintMessage(string message);
        void PrintError(string message);

    }
}
