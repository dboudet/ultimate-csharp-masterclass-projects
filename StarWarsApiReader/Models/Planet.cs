using System.Reflection;
using StarWarsApiReader.DTO;

namespace StarWarsApiReader.Models;

public readonly record struct Planet
{
    public string Name { get; }
    public int? Diameter { get; }
    public int? Population { get; }
    public int? SurfaceWater { get; }

    public Planet(
        string name,
        int? diameter,
        int? population,
        int? surfaceWater)
    {
        Name = name;
        Diameter = diameter;
        Population = population;
        SurfaceWater = surfaceWater;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var Name = planetDto.Name;
        _ = int.TryParse(planetDto.Diameter, out int Diameter);
        _ = int.TryParse(planetDto.Population, out int Population);
        _ = int.TryParse(planetDto.SurfaceWater, out int SurfaceWater);

        return new Planet(Name, Diameter, Population, SurfaceWater);
    }
}
