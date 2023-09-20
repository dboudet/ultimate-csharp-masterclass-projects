using GameDataParser.App;
using GameDataParser.ExceptionLogger;
using GameDataParser.FileHandler;
using GameDataParser.InputHandler;
using GameDataParser.UserInteractions;


const string fileName = "games";
//const string fileName = "gamesInvalidFormat";
const string extension = "json";
const string logFilePath = "log.txt";

IUserInteraction userInteraction = new UserConsoleInteraction();
IFileReader jsonFileReader = new JsonFileReader(fileName, extension);
IUserInputHandler inputHander = new UserInputHandler();
ILogger logger = new TextFileLogger(logFilePath);

var app = new GameDataParserApp(
    jsonFileReader,
    inputHander,
    userInteraction,
    logger);

app.Run();