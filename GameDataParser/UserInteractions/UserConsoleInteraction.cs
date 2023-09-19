namespace GameDataParser.UserInteractions
{
    public class UserConsoleInteraction : IUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string? ReadUserInput()
        {
            return Console.ReadLine();
        }

        public void EndProgram()
        {
            ShowMessage("Press any key to close.");
            Console.ReadKey();
        }
    }
}
