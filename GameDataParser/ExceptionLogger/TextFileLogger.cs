namespace GameDataParser.ExceptionLogger
{
    public class TextFileLogger : ILogger
    {
        readonly string Separator = Environment.NewLine;
        public bool LogFileExists { get; }
        public string? ExistingLogContents { get; set; }
        public string LogFilePath { get; init; }

        public TextFileLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
            LogFileExists = File.Exists(logFilePath);
        }

        public string GetExistingLogEntries() =>
            LogFileExists ? File.ReadAllText(LogFilePath) : "";
        public void Log(Exception exception)
        {
            string logContents = GetExistingLogEntries();
            string newException =
                $"[{new DateTime().ToString()}], " +
                $"Exception message: {exception.Message}, " +
                $"Stack trace: {exception.StackTrace}";
            File.WriteAllText(LogFilePath, logContents + Separator + newException);
        }

    }
}
