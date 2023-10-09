namespace StarWarsApiReader.UserInteraction;

public interface IInputValidation
{
    bool ValidateInput<T>(string? input);
}