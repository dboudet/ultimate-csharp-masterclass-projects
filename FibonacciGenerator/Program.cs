using FibonacciGenerator;


var fibonacciGenerator = new SequenceGenerator(2);

try
{
    var result = fibonacciGenerator.Run();
    Console.WriteLine(string.Join(",", result));
}
catch (Exception e)
{
    Console.WriteLine("Sorry. A sequence could not be generated.");
    Console.WriteLine($"Exception thrown: {e.Message}");
}



Console.WriteLine("press key to quit");
Console.ReadKey();