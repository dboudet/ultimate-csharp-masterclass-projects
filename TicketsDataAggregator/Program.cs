using TicketsDataAggregator.App;

const string TicketsFolder = "Tickets";

try
{
    var ticketsAggregator = new TicketsAggregator(TicketsFolder);
    ticketsAggregator.Run();
}
catch (Exception e)
{
    Console.WriteLine("An exception occurred. " +
        "Exception message: " + e.Message);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
