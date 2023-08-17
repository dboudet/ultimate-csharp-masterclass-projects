
bool stopProgram = false;

do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");

    //string? userChoice = Console.ReadLine();
    string? userChoice = Console.ReadLine().ToUpper();

    if (userChoice == "S")
    {
        PrintSelectedOption("See all todos");
    }
    else if (userChoice == "A")
    {
        PrintSelectedOption("Add a todo");
    }
    else if (userChoice == "R")
    {
        PrintSelectedOption("Remove a todo");
    }
    else if (userChoice == "E")
    {
        PrintSelectedOption("Exit");
        handleStopProgram();
        break;
    }
    else Console.WriteLine("Invalid Input");

    Console.WriteLine("Would you like to continue? [Y/N]");
    string? userContinueInput = Console.ReadLine().ToUpper();

    if (userContinueInput != "Y")
    {
        handleStopProgram();
    }
}
while (stopProgram == false);



//Console.ReadKey();

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}

void handleStopProgram()
{
    stopProgram = true;
    Console.WriteLine("Thank you. Press any key to close.");
    Console.ReadKey();
}



// her approach
//switch (userChoice)
//{
//    case "S":
//    case "s":
//        PrintSelectedOption("See all todos");
//        break;
//    case "A":
//    case "a":
//        PrintSelectedOption("Add a todo");
//        break;
//    case "R":
//    case "r":
//        PrintSelectedOption("Remove a todo");
//        break;
//    case "E":
//    case "e":
//        PrintSelectedOption("Exit");
//        break;
//    default:
//        Console.WriteLine("Invalid Input");
//        break;
//}

