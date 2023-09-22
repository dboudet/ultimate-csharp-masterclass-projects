namespace GameDataParser.ExceptionLogger
{
    public class TextFileLogger : ILogger
    {
        private readonly string Separator = Environment.NewLine;
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
                $"[{DateTime.Now}] {Separator}" +
                $"Exception message: {exception.Message} {Separator}" +
                $"Stack trace: {exception.StackTrace} {Separator}";
            File.WriteAllText(LogFilePath, logContents + Separator + newException);
        }

    }
}
