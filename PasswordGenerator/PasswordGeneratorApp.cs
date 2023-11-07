using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PasswordGeneratorTests")]

namespace PasswordGenerator;

public class PasswordGeneratorApp
{
    private readonly IRandom _random = new RandomWrapper();

    public PasswordGeneratorApp(IRandom randomWrapper)
    {
        _random = randomWrapper;
    }

    public string Generate(
        int left, int right, bool includeSpecial)
    {
        ValidateRange(left, right);

        var availableCharacters = GetAvailableCharacters(includeSpecial);
        var length = _random.Next(left, right + 1);
        var result = CreatePassword(availableCharacters, length);
        return result;
    }

    private void ValidateRange(int left, int right)
    {
        if (left < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(left)} must be greater than 0");
        }
        if (right < left)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(left)} must be smaller than {nameof(right)}");
        }
    }

    private string GetAvailableCharacters(bool includeSpecial)
    {
        return includeSpecial ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    }

    private string CreatePassword(string characters, int length)
    {
        return new string(Enumerable.Repeat(characters, length)
            .Select(chars => chars[_random.Next(chars.Length)])
            .ToArray());
    }
}
