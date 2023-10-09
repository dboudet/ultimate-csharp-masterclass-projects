namespace StarWarsApiReader.UserInteraction
{
    public interface IUserInput
    {
        void EndProgramInput();
        string? GetInput();
    }
}