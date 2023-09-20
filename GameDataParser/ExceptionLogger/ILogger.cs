namespace GameDataParser.ExceptionLogger
{
    public interface ILogger
    {
        bool LogFileExists { get; }
        string? ExistingLogContents { get; set; }
        string LogFilePath { get; init; }

        string ReadExistingLogEntries();
        void AddExceptionToLog(string exceptionMessage);
    }
}
