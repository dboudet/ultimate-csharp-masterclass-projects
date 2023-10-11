using StarWarsApiReader.ApiReader;
using StarWarsApiReader.App;
using StarWarsApiReader.DataInteraction;
using StarWarsApiReader.UserDisplay;
using StarWarsApiReader.UserInteraction;


var baseUrl = "https://swapi.dev/";
var requestPath = "api/planets/";

//IApiReader _apiReader = new MockStarWarsApiDataReader(baseUrl, requestPath);
IApiReader _apiReader = new ApiReader(baseUrl, requestPath);
IUserMessages _userMessages = new ConsoleUserMessages();
IUserInput _userInput = new ConsoleUserInput();
ITablePrinter _tablePrinter = new ConsoleTablePrinter();
IPropertyData _propertyData = new PropertyData();
IInputValidation _inputValidation = new InputValidation(_propertyData);

StarWarsApiReaderApp _app = new StarWarsApiReaderApp(
    _apiReader,
    _userMessages,
    _tablePrinter,
    _userInput,
    _inputValidation,
    _propertyData);


try
{
    await _app.Run();
}
catch (Exception ex)
{
    _userMessages.DisplayErrorMessage(ex.Message);
}

_userMessages.EndProgram();


