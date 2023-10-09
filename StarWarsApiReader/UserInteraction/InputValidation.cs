using StarWarsApiReader.DataInteraction;
namespace StarWarsApiReader.UserInteraction;

public class InputValidation : IInputValidation
{
    public InputValidation(IPropertyData propertyData)
    {
        PropertyData = propertyData;
    }

    public IPropertyData PropertyData { get; }

    public bool ValidateInput<T>(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        if (PropertyData.GetPropertyFromInput<T>(input) is null)
            return false;

        return true;
    }
}
