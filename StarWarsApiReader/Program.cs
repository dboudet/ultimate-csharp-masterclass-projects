using System.Text.Json;
using System.Threading.Channels;
using StarWarsApiReader.ApiReader;
using StarWarsApiReader.Planets;
using StarWarsApiReader.TablePrinter;


var baseUrl = "https://swapi.dev/api/";
var requestPath = "planets/";

var starWarsApiData = await ApiReader.Read(baseUrl, requestPath);


var planetsData = JsonSerializer.Deserialize<PlanetsDataFromApi>(starWarsApiData);
//Console.WriteLine(planetsData);

var tablePrinter = new TablePrinter();
var planetsForTable = planetsData.Results
    .Select(p => new PlanetAbridged(p.Name, p.Population, p.Diameter, p.SurfaceWater));
tablePrinter.PrintTable(planetsForTable);


var validInputEntered = false;

while (validInputEntered == false)
{

    Console.WriteLine("The statistics of which property would you like to see?");
    Console.WriteLine("population");
    Console.WriteLine("diameter");
    Console.WriteLine("surface water");

    var userInput = Console.ReadLine();



    string planetsForTable2 = userInput switch
    {
        "population" => "display population min and max (set validInputEntered to true)",
        "diameter" => "display diameter min and max (set validInputEntered to true)",
        "surface water" => "display surface water min and max (set validInputEntered to true)",
        _ => "Invalid option. Please try again."
    };
    Console.WriteLine(planetsForTable2);
}


Console.WriteLine("Press any key to close.");
Console.ReadKey();




