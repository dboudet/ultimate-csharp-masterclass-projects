using NUnit.Framework;
using UnitTestsSectionExamples;

namespace UnitTestsSectionExamplesTests;

// not needed as long as class includes at least one [Test] method
[TestFixture]
public class EnumExtenstionTests
{
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyEnumerable()
    {
        var input = Enumerable.Empty<int>();

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(0, result);
    }

    //[TestCase(new int[] { 3, 1, 4, 6, 7 }, 10)]
    // use TestCaseSource when you need to pass a parameter
    // that can't be done via Attribute (which can only take simple types or arrays of them.
    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfAnyEvenNumbersAreIncluded(
        IEnumerable<int> input, int expected)
    {
        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(expected, result, $"given {string.Join(",", input)}");
    }

    private static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] { new int[] { 3, 1, 4, 6, 7 }, 10},
            new object[] { new List<int> { 100, 200, 1}, 300 },
            new object[] { new List<int> { -3, -5, 0 }, 0 },
            new object[] { new List<int> { -4, -8 }, -12 }
        };
    }

    // [TestCase(8, 8)] // can include the expected result for each test case
    [TestCase(8)]
    [TestCase(-8)]
    [TestCase(6)]
    [TestCase(0)]
    // for testing passing result with test case
    //public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number, int expected)
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(number, result);
        //Assert.AreEqual(expected, result);
    }

    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZero_IfOnlyNumberInInputIsOdd(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        //Assert.AreEqual(0, result);
        Assert.Zero(result);
    }


    [Test]
    public void SumOfEvenNumbers_ShallThrowException_ForNullInput()
    {
        IEnumerable<int>? input = null;

        Assert.Throws<ArgumentNullException>(
            () => input!.SumOfEvenNumbers());
    }

}