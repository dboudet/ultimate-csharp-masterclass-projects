Console.WriteLine("Hello!");

Console.WriteLine("Input the first number:");
int? firstNum = int.Parse(Console.ReadLine());

Console.WriteLine("Input the second number:");
int? secondNum = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");

string? operationInput = Console.ReadLine()?.ToUpper();


// My original approach
//Console.WriteLine(ConstructFormula(firstNum, secondNum, operationInput));

//string ConstructFormula(int? num1, int? num2, string? operation)
//{
//    if (operation == "A") return num1 + " + " + num2 + " = " + (num1 + num2);
//    else if (operation == "S") return num1 + " - " + num2 + " = " + (num1 - num2);
//    else if (operation == "M") return num1 + " * " + num2 + " = " + (num1 * num2);
//    else return "Invalid option";
//}

// her approach
if (EqualsCaseInsensitive(operationInput, "A"))
{
    var sum = firstNum + secondNum;
    PrintFinalEquation(firstNum, secondNum, sum, "+");
}
else if (EqualsCaseInsensitive(operationInput, "S"))
{
    var diff = firstNum - secondNum;
    PrintFinalEquation(firstNum, secondNum, diff, "-");
}
else if (EqualsCaseInsensitive(operationInput, "M"))
{
    var mult = firstNum * secondNum;
    PrintFinalEquation(firstNum, secondNum, mult, "*");
}
else Console.WriteLine("Invalid option");

void PrintFinalEquation(int? num1, int? num2, int? result, string @operator)
{
    //Console.WriteLine(num1 + " " + @operator + num2 + " = " + result);
    Console.WriteLine($"{num1} {@operator} {num2} = {result}");
}

bool EqualsCaseInsensitive(string str1, string str2)
{
    return str1.ToUpper() == str2;
}



Console.WriteLine("Press any key to close");
Console.ReadKey();