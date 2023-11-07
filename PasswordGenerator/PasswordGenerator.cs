public class PasswordGenerator
{
    private readonly IRandom _random;

    public PasswordGenerator(IRandom randomWrapper)
    {
        _random = randomWrapper;
    }

    public string Generate(
        int minLength, int maxLength, bool includeSpecial)
    {
        var availableCharacters = includeSpecial ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        ValidateRange(minLength, maxLength);
        int length = GeneratePasswordLength(minLength, maxLength);

        return CreatePassword(availableCharacters, length);
    }

    private void ValidateRange(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {nameof(maxLength)}");
        }
    }

    private int GeneratePasswordLength(int minLength, int maxLength)
    {
        return _random.Next(minLength, maxLength + 1);
    }

    private string CreatePassword(string availableCharacters, int length)
    {
        char[] passwordCharacters =
            Enumerable.Repeat(availableCharacters, length)
            .Select(characters => characters[_random.Next(characters.Length)])
            .ToArray();

        return new string(passwordCharacters);
    }
}
