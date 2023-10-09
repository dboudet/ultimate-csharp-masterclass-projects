using System.Text.Json;
using StarWarsApiReader.ApiReader;
using StarWarsApiReader.App;
using StarWarsApiReader.DataInteraction;
using StarWarsApiReader.Planets;
using StarWarsApiReader.UserDisplay;
using StarWarsApiReader.UserInteraction;


IUserMessages _userMessages = new ConsoleUserMessages();
IUserInput _userInput = new ConsoleUserInput();
ITablePrinter _tablePrinter = new ConsoleTablePrinter();
IPropertyData _propertyData = new PropertyData();
IInputValidation _inputValidation = new InputValidation(_propertyData);
StarWarsApiReaderApp _app = new StarWarsApiReaderApp(
    _userMessages,
    _userInput,
    _inputValidation,
    _propertyData);

var baseUrl = "https://swapi.dev/api/";
var requestPath = "planets/";

try
{
    var starWarsApiData = await ApiReader.Read(baseUrl, requestPath);

    var planetsData = JsonSerializer.Deserialize<PlanetsDataFromApi>(starWarsApiData)?
        .Results ?? throw new FormatException("Problem processing data from Star Wars API.");

    _tablePrinter.PrintTable(planetsData);

    _userMessages.DisplayProperties();

    _app.Run(planetsData);
}
catch (Exception ex)
{
    _userMessages.DisplayErrorMessage(ex);
}

_userMessages.EndProgram();


