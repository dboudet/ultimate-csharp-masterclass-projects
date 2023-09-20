using GameDataParser.ExceptionLogger;
using GameDataParser.FileHandler;
using GameDataParser.InputHandler;
using GameDataParser.UserInteractions;

namespace GameDataParser.App
{

    public class GameDataParserApp
    {
        private readonly IFileReader _fileReader;
        private readonly IUserInputHandler _userInputHandler;
        private readonly IUserInteraction _userInteraction;
        private readonly ILogger _logger;

        public bool EndProgram { get; private set; } = false;


        public GameDataParserApp(
            IFileReader fileReader,
            IUserInputHandler userInputHandler,
            IUserInteraction userInteraction,
            ILogger logger)
        {
            _fileReader = fileReader;
            _userInputHandler = userInputHandler;
            _userInteraction = userInteraction;
            _logger = logger;
        }

        public void Run()
        {
            while (!EndProgram)
            {
                _userInteraction.ShowMessage("Enter the name of the file you want to read:");

                string? input = Console.ReadLine();

                bool isInputNull = true;
                bool isInputEmpty = true;

                public bool ValidateInput(string? input)
                {

                }

            }

            _userInteraction.EndProgram();
        }
    }


}
