
namespace PasswordGenerator;

public interface IRandom
{
    int Next(int left, int right);
    int Next(int maxValue);
}

public class RandomWrapper : IRandom
{
    public int Next(int left, int right)
    {
        return new Random().Next(left, right + 1);
    }

    public int Next(int maxValue)
    {
        return new Random().Next(maxValue);
    }
}
