﻿using GameDataParser.App;
using GameDataParser.ExceptionLogger;
using GameDataParser.FileHandler;
using GameDataParser.UserInteractions;


const string logFilePath = "log.txt";

IUserInteraction userInteraction = new UserConsoleInteraction();
IFileReader fileReader = new JsonFileReader();
ILogger logger = new TextFileLogger(logFilePath);

var app = new GameDataParserApp(
    fileReader,
    userInteraction,
    logger);

try
{
    app.Run();
}
catch (Exception ex)
{
    logger.Log(ex);
}
userInteraction.EndProgram();
