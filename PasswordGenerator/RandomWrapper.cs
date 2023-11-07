
namespace PasswordGenerator;

public interface IRandom
{
    int Next(int lowerBound, int upperBound);
    int Next(int maxLength);
}

public class RandomWrapper : IRandom
{
    private readonly Random _random = new();
    public int Next(int lowerBound, int upperBound)
    {
        return _random.Next(lowerBound, upperBound);
    }

    public int Next(int maxLength)
    {
        return _random.Next(maxLength);
    }
}
