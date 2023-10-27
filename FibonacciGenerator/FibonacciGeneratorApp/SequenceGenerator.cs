using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FibonacciGeneratorTests")]

namespace FibonacciGenerator;

internal class SequenceGenerator
{
    readonly int[] _starter = { 0, 1 };
    public int Length { get; }
    public SequenceGenerator(int length)
    {
        Length = length;
    }
    public int[] Run()
    {
        try
        {
            ValidateInput();
        }
        catch (Exception e)
        {
            throw e;
        }
        var result = new int[Length];

        if (Length < 2)
        {
            foreach (int i in result)
            {
                result[i] = _starter[i];
            }
            return result;
        }
        else
        {
            _starter.CopyTo(result, 0);

            for (int i = 2; i < result.Length; ++i)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result;
        }
    }

    private bool ValidateInput()
    {
        if (Length < 0)
            throw new ArgumentOutOfRangeException(
                $"{nameof(Length)} cannot be smaller than 0.");

        const int maxValue = 46;
        if (Length > maxValue)
            throw new ArgumentOutOfRangeException(
                $"{nameof(Length)} cannot be larger than {maxValue}.");

        return true;
    }
}
