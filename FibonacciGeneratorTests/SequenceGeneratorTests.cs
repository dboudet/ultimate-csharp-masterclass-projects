using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        //[TestCase(-23)]
        //[TestCase(47)]
        //public void SequenceGenerator_ShallThrow_IfInputOutOfRange(int length)
        //{
        //    var generator = new SequenceGenerator(length);

        //    Assert.Throws<ArgumentOutOfRangeException>(
        //        () => generator.Run());
        //}

        [TestCase(-23)]
        [TestCase(-1)]
        public void SequenceGenerator_ShallThrow_IfInputIsNegative(int input)
        {
            var generator = new SequenceGenerator(input);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => generator.Run());
        }

        [TestCase(47)]
        [TestCase(123)]
        public void SequenceGenerator_ShallThrow_IfInputIsGreaterThan46(int input)
        {
            var generator = new SequenceGenerator(input);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => generator.Run());
        }

        [TestCase(3)]
        [TestCase(14)]
        [TestCase(29)]
        [TestCase(46)]
        public void SequenceGenerator_ShallProduceGivenLengthResult_WhenValidInput(int length)
        {
            var generator = new SequenceGenerator(length);
            var result = generator.Run();
            Assert.AreEqual(length, result.Length);
        }

        [TestCase(3, new int[] { 0, 1, 1 })]
        [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
        [TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        public void SequenceGenerator_ShallProduceValidFibonacciSequence(
            int length, int[] expected)
        {
            var generator = new SequenceGenerator(length);
            var result = generator.Run();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SequenceGenerator_ShallGiveCorrectFinalNumber_WhenInputIs46()
        {
            var generator = new SequenceGenerator(46);
            var output = generator.Run();
            Assert.AreEqual(1134903170, output.Last());
        }

        [Test]
        public void SequenceGenerator_ShallGiveEmptyArray_WhenInputIsZero()
        {
            var generator = new SequenceGenerator(0);
            var result = generator.Run();
            Assert.IsEmpty(result);
        }

        [Test]
        public void SequenceGenerator_ShallGiveArrayOf_0_WhenInputIsOne()
        {
            var generator = new SequenceGenerator(1);
            var result = generator.Run();
            Assert.AreEqual(new int[] { 0 }, result);
        }

        [Test]
        public void SequenceGenerator_ShallGiveArrayOf_0_1_WhenInputIsTwo()
        {
            var generator = new SequenceGenerator(2);
            var result = generator.Run();
            Assert.AreEqual(new int[] { 0, 1 }, result);
        }

    }
}