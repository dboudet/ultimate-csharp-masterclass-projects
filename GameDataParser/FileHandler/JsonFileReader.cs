namespace GameDataParser.FileHandler
{
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

        public bool DoesGamesFileExist()
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

        public Games ParseFileContents(string fileContents)
        {
            throw new NotImplementedException();
        }
    }
}
