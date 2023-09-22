namespace GameDataParserHers.FileReader
{
    public class LocalFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }

}
