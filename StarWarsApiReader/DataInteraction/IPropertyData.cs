using System.Reflection;

namespace StarWarsApiReader.DataInteraction
{
    public interface IPropertyData
    {
        Dictionary<string, KeyValuePair<string, int>> GetMinAndMaxByProperty<T>(string input, IEnumerable<T> collection);
        PropertyInfo? GetPropertyFromInput<T>(string input);
    }
}