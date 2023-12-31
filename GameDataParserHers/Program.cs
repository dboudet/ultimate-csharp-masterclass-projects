﻿using GameDataParserHers.App;
using GameDataParserHers.DataAccess;
using GameDataParserHers.Logging;
using GameDataParserHers.UserInteraction;

var userInteractor = new ConsoleUserInteractor();
var app = new GameDataParserApp(
    userInteractor,
    new GamesPrinter(userInteractor),
    new VideoGamesDeserializer(userInteractor),
    new LocalFileReader());
var logger = new Logger("log.txt");


try
{
    app.Run();
}
catch (Exception ex)
{
    userInteractor.PrintMessage(
        "Sorry! The application has experienced an unexpected errror " +
        "and will have to be closed.");
    logger.Log(ex);
}

userInteractor.PrintMessage("Press any key to close.");
Console.ReadKey();
