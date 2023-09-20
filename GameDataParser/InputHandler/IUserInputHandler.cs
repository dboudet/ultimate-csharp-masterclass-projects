namespace GameDataParser.InputHandler
{
    public interface IUserInputHandler
    {
        public bool isInputValid(string? input);
        public bool IsInputNotNull(string? input);
        public bool IsInputNotEmpty(string input);
        public bool IsInputValidFileName(string input);
    }

}
