namespace GameDataParser.FileHandler
{
    public interface IFileReader
    {
        public string FilePath { get; init; }
        bool IsValidFilePath(string fileName, string extension);
        bool DoesGamesFileExist();
        string ReadFile();
        // THIS SHOULD END UP BEING A GAMES OBJECT
        // BUT DO WE KEEP THIS RETURNING A STRING?
        Games ParseFileContents(string fileContents);
        void HandleInvalidJson(string fileContents);

    }
}
