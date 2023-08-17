Console.WriteLine("Hello!");

Console.WriteLine("Input the first number:");
int? firstNum = int.Parse(Console.ReadLine());

Console.WriteLine("Input the second number:");
int? secondtNum = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");

string? operationInput = Console.ReadLine()?.ToUpper();

Console.WriteLine(ConstructFormula(firstNum, secondtNum, operationInput));

string ConstructFormula(int? num1, int? num2, string? operation)
{
    if (operation == "A") return num1 + " + " + num2 + " = " + (num1 + num2);
    if (operation == "S") return num1 + " - " + num2 + " = " + (num1 - num2);
    if (operation == "M") return num1 + " * " + num2 + " = " + (num1 * num2);
    else return "Invalid option";
}



Console.WriteLine("Press any key to close");
Console.ReadKey();