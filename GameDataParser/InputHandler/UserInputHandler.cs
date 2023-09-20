namespace GameDataParser.InputHandler
{
    public class UserInputHandler : IUserInputHandler
    {
        public bool isInputValid(string? input)
        {
            return
                IsInputNotNull(input) &&
                IsInputNotEmpty(input) &&
                IsInputValidFileName(input);
        }

        public bool IsInputNotNull(string? input)
        {
            return input is null;
        }

        public bool IsInputNotEmpty(string input)
        {
            return input != "";
        }

        public bool IsInputValidFileName(string input)
        {
            return input.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 || false;
        }
    }

}
