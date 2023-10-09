namespace StarWarsApiReader.UserDisplay;

public interface ITablePrinter
{
    void PrintColumnHeaders(IEnumerable<string> columnHeaders);
    void PrintRow(IEnumerable<string> row);
    void PrintTable<T>(IEnumerable<T> data);
}