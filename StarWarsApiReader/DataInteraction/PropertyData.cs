using System.Reflection;

namespace StarWarsApiReader.DataInteraction;

public class PropertyData : IPropertyData
{
    public PropertyInfo? GetPropertyFromInput<T>(string input)
    {
        string normalizedInput = string.Join("", input
            .Split(default(string[]), StringSplitOptions.RemoveEmptyEntries))
            .ToLower();

        return typeof(T).GetProperty(
            normalizedInput,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    }
    public Dictionary<string, KeyValuePair<string, int>> GetMinAndMaxByProperty<T>(
        string input,
        IEnumerable<T> collection)
    {
        if (collection is null)
            throw new ArgumentNullException($"Problem retrieving {typeof(T)} data.");

        var propertyName = GetPropertyFromInput<T>(input);

        if (propertyName is null)
            throw new ArgumentNullException($"Could not find property {input}.");

        var propertiesWithIntValues = new Dictionary<string, int>();

        foreach (var item in collection)
        {
            bool isInt = int.TryParse(propertyName.GetValue(item)!.ToString(), out int valueAsInt);
            if (isInt)
            {
                string _name = typeof(T).GetProperty("Name")!.GetValue(item)!.ToString() ?? "undefined";
                propertiesWithIntValues.Add(_name, valueAsInt);
            }
        }

        var maxValue = propertiesWithIntValues.Values.Max();
        var minValue = propertiesWithIntValues.Values.Min();

        var result = new Dictionary<string, KeyValuePair<string, int>>
        {
            { "Max", propertiesWithIntValues.First(v => v.Value == maxValue) },
            { "Min", propertiesWithIntValues.First(v => v.Value == minValue) }
        };
        var minObject = propertiesWithIntValues.First(v => v.Value == minValue);
        return result;
    }
}
