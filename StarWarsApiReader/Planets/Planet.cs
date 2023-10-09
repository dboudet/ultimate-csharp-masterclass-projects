using System.Text.Json.Serialization;

namespace StarWarsApiReader.Planets;

public record Planet(
    //[property: JsonPropertyName("rotation_period")] string RotationPeriod,
    //[property: JsonPropertyName("orbital_period")] string OrbitalPeriod,
    //[property: JsonPropertyName("climate")] string Climate,
    //[property: JsonPropertyName("gravity")] string Gravity,
    //[property: JsonPropertyName("terrain")] string Terrain,
    //[property: JsonPropertyName("residents")] IReadOnlyList<string> Residents,
    //[property: JsonPropertyName("films")] IReadOnlyList<string> Films,
    //[property: JsonPropertyName("created")] DateTime Created,
    //[property: JsonPropertyName("edited")] DateTime Edited,
    //[property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("diameter")] string Diameter,
    [property: JsonPropertyName("surface_water")] string SurfaceWater,
    [property: JsonPropertyName("population")] string Population
);

public record PlanetsDataFromApi(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("next")] string Next,
    [property: JsonPropertyName("previous")] object Previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Planet> Results
);
