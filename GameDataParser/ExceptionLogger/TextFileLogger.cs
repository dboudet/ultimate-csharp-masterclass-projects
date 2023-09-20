namespace GameDataParser.ExceptionLogger
{
    public class TextFileLogger : ILogger
    {
        public bool LogFileExists { get; }
        public string? ExistingLogContents { get; set; }
        public string LogFilePath { get; init; }

        public TextFileLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
            LogFileExists = File.Exists(logFilePath);
        }

        public string ReadExistingLogEntries() =>
            LogFileExists ? File.ReadAllText(LogFilePath) : "";
        public void AddExceptionToLog(string exceptionMessage)
        {
            throw new NotImplementedException();
        }

    }
}
