namespace CookieCookbook.AppSettings
{
    public enum FileFormat
    {
        json,
        txt
    }

    public sealed class UserSettings
    {
        public FileFormat SelectedFormat { get; init; }
        public string FilePath { get; init; }
        public UserSettings(FileFormat format)
        {
            SelectedFormat = format;
            FilePath = $"/recipe.{format}";
        }
    }

}
