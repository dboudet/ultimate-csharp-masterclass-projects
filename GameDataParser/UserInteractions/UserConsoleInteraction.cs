using GameDataParser.FileHandler;
using GameDataParser.Games;

namespace GameDataParser.UserInteractions
{
    public class UserConsoleInteraction : IUserInteraction
    {
        public void ShowMessage(string message) => Console.WriteLine(message);
        public void ShowErrorMessage(string errMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ShowMessage(errMessage);
            Console.ResetColor();
        }
        public string? ReadUserInput() => Console.ReadLine();
        public string GetFilePathFromUser()
        {
            string? filePath = "";

            while (string.IsNullOrEmpty(filePath))
            {
                ShowMessage("Enter the name of the file you want to read:");
                string? input = ReadUserInput();

                if (isInputValid(input))
                {
                    filePath = input;
                }
            }
            return filePath;
        }
        public bool isInputValid(string? input)
        {
            if (input is null)
            {
                ShowMessage("File name cannot be null.");
                return false;
            }
            if (input == "")
            {
                ShowMessage("File name cannot be empty.");
                return false;
            }
            if (input.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                ShowMessage("Invalid file name.");
                return false;
            }
            if (!File.Exists(input))
            {
                ShowMessage("File not found.");
                return false;
            }
            return true;
        }
        public void PrintGames(GamesRegister games)
        {
            ShowMessage("Loaded games are:");

            foreach (var game in games.All)
            {
                ShowMessage(game.ToString());
            }
        }
        public void EndProgram()
        {
            ShowMessage("Press any key to close.");
            Console.ReadKey();
        }
    }
}
