using StarWarsApiReader.DataInteraction;
using StarWarsApiReader.Planets;
using StarWarsApiReader.UserDisplay;
using StarWarsApiReader.UserInteraction;

namespace StarWarsApiReader.App;

public class StarWarsApiReaderApp
{
    public IUserMessages UserMessages { get; }
    public IUserInput UserInput { get; }
    public IInputValidation InputValidation { get; }
    public IPropertyData PropertyData { get; }

    public StarWarsApiReaderApp(
        IUserMessages userMessages,
        IUserInput userInput,
        IInputValidation inputValidation,
        IPropertyData propertyData)
    {
        UserMessages = userMessages;
        UserInput = userInput;
        InputValidation = inputValidation;
        PropertyData = propertyData;
    }

    public void Run<T>(IReadOnlyList<T> dataFromApi)
    {
        var validInputEntered = false;

        while (validInputEntered == false)
        {
            var input = UserInput.GetInput();

            if (!InputValidation.ValidateInput<Planet>(input))
            {
                UserMessages.DisplayInvalidInputResponse();
                continue;
            }

            var minAndMaxByProperty = PropertyData.GetMinAndMaxByProperty(input!, dataFromApi);

            UserMessages.DisplayResults(input!, minAndMaxByProperty);
            validInputEntered = true;
        }
    }
}
