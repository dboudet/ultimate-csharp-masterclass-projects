using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestsSectionExamplesTests")]

namespace UnitTestsSectionExamples;
internal static class EnumExtenstions
{
    internal static int SumOfEvenNumbers(
        this IEnumerable<int> numbers)
    {
        return numbers.Where(IsEven).Sum();
        //int sum = 0;

        //foreach (int number in numbers)
        //{
        //    if (number % 2 == 0)
        //    {
        //        sum += number;
        //    }
        //}
        //return sum;
    }

    // private methods are tested implicitly by testing
    // the methods calling them - so they don't need to tested directly
    // though I'd think each private method's functionality
    // should be a Test Case for the called method.
    private static bool IsEven(int number) => number % 2 == 0;
}