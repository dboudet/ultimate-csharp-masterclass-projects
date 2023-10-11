using System.Text.Json;
using StarWarsApiReader.ApiReader;
using StarWarsApiReader.DataInteraction;
using StarWarsApiReader.DTO;
using StarWarsApiReader.Models;
using StarWarsApiReader.UserDisplay;
using StarWarsApiReader.UserInteraction;

namespace StarWarsApiReader.App;

public class StarWarsApiReaderApp
{
    public IApiReader ApiReader { get; }
    public IUserMessages UserMessages { get; }
    public ITablePrinter TablePrinter { get; }
    public IUserInput UserInput { get; }
    public IInputValidation InputValidation { get; }
    public IPropertyData PropertyData { get; }

    public StarWarsApiReaderApp(
        IApiReader _apiReader,
        IUserMessages userMessages,
        ITablePrinter _tablePrinter,
        IUserInput userInput,
        IInputValidation inputValidation,
        IPropertyData propertyData)
    {
        ApiReader = _apiReader;
        UserMessages = userMessages;
        TablePrinter = _tablePrinter;
        UserInput = userInput;
        InputValidation = inputValidation;
        PropertyData = propertyData;
    }

    public async Task Run()
    {
        var swapiJsonData = await ApiReader.Read();

        Root planetsData = JsonSerializer.Deserialize<Root>(swapiJsonData)
            ?? throw new FormatException("Problem processing data from Star Wars API.");

        IEnumerable<Planet> planets = ToPlanets(planetsData);


        TablePrinter.PrintTable(planets);
        UserMessages.DisplayProperties();

        var validInputEntered = false;
        while (validInputEntered == false)
        {
            var input = UserInput.GetInput();

            if (!InputValidation.ValidateInput<Result>(input))
            {
                UserMessages.DisplayInvalidInputResponse();
                continue;
            }

            var minAndMaxByProperty = PropertyData.GetMinAndMaxByProperty(input!, planets);

            UserMessages.DisplayResults(input!, minAndMaxByProperty);
            validInputEntered = true;
        }
    }
    private IEnumerable<Planet> ToPlanets(Root? planetsDataFromJson)
    {
        if (planetsDataFromJson is null)
            throw new ArgumentNullException(nameof(planetsDataFromJson));

        var planets = new List<Planet>();
        foreach (var planetDto in planetsDataFromJson.Results)
        {
            Planet planet = (Planet)planetDto;
            planets.Add(planet);
        }

        return planets;
    }


}
