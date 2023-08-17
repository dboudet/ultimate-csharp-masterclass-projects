Console.WriteLine("What do you want to do?");
Console.WriteLine("[S]ee all todos");
Console.WriteLine("[A]dd a todo");
Console.WriteLine("[R]emove a todo");
Console.WriteLine("[E]xit");

// TODO: handle user input
/*
 * this is a 
 * multiline
 * comment
*/

string? userChoice = Console.ReadLine();

switch (userChoice)
{
    case "S":
        PrintSelectedOption("See all todos");
        break;
    case "A":
        PrintSelectedOption("Add a todo");
        break;
    case "R":
        PrintSelectedOption("Remove a todo");
        break;
    case "E":
        PrintSelectedOption("Exit");
        break;
    default: Console.WriteLine("Invalid Input");
        break;
}

//if (userChoice == "S")
//{
//    PrintSelectedOption("See all todos");
//}
//else if (userChoice == "A")
//{
//    PrintSelectedOption("Add a todo");
//}
//else if (userChoice == "R")
//{
//    PrintSelectedOption("Remove a todo");
//}
//else if (userChoice == "E")
//{
//    PrintSelectedOption("Exit");
//}
Console.ReadKey();

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}