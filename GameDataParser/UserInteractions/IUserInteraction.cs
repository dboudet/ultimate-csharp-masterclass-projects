using GameDataParser.FileHandler;
using GameDataParser.Games;

namespace GameDataParser.UserInteractions
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        public void ShowErrorMessage(string errMessage);
        string? ReadUserInput();
        public string GetFilePathFromUser();
        public bool isInputValid(string? input);
        public void PrintGames(GamesRegister games);
        void EndProgram();

    }
}
