namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private Dictionary<string, bool> _boolData = new();
    private Dictionary<string, int> _intData = new();
    private Dictionary<string, decimal> _decimalData = new();
    private Dictionary<string, string> _stringData = new();

    public void AssignCell(string columnName, bool value)
    {
        _boolData[columnName] = value;
    }
    public void AssignCell(string columnName, int value)
    {
        _intData[columnName] = value;
    }
    public void AssignCell(string columnName, decimal value)
    {
        _decimalData[columnName] = value;
    }
    public void AssignCell(string columnName, string value)
    {
        _stringData[columnName] = value;
    }

    public object? GetAtColumn(string columnName)
    {
        if (_boolData.ContainsKey(columnName))
        {
            return _boolData[columnName];
        }
        if (_intData.ContainsKey(columnName))
        {
            return _intData[columnName];
        }
        if (_decimalData.ContainsKey(columnName))
        {
            return _decimalData[columnName];
        }
        if (_stringData.ContainsKey(columnName))
        {
            return _stringData[columnName];
        }
        return null;
    }
}