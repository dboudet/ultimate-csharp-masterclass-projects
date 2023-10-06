using System.Reflection;
using System.Reflection.PortableExecutable;

namespace StarWarsApiReader.TablePrinter;

public class TablePrinter
{
    //private static string Separator(int stringLength) =>
    //stringLength > 17 ? "\t\t|" : "\t\t\t|";
    public void PrintColumnHeaders(IEnumerable<string> columnHeaders)
    {
        foreach (var header in columnHeaders)
        {
            int placement = 0;
            string placementAsString = placement.ToString();
            Console.Write($"{{{placementAsString},18}}", header, "|");
            placement += 20;
        }
        Console.WriteLine();
        Console.WriteLine(new String('-', 80));
    }

    public void PrintRow(IEnumerable<string> row)
    {
        foreach (var item in row)
        {
            int placement = 0;
            string placementAsString = placement.ToString();
            Console.Write($"{{{placementAsString},18}}", item, "|");
            placement += 20;
        }
        Console.WriteLine();
    }

    public void PrintTable<T>(IEnumerable<T> data)
    {
        PropertyInfo[] dataProperties = data.First().GetType().GetProperties();
        var columnHeaders = dataProperties.Select(v => v.Name);

        PrintColumnHeaders(columnHeaders);

        foreach (T row in data)
        {
            var rowValues = new List<string>();
            foreach (PropertyInfo prop in dataProperties)
            {
                if (prop.GetValue(row) is null) return;
                rowValues.Add(prop.GetValue(row)!.ToString()!);
            }
            PrintRow(rowValues);
        }
    }
}
