using Moq;
using NUnit.Framework;

[TestFixture]
public class PasswordGeneratorTests
{
    PasswordGenerator _cut;
    Mock<IRandom> _mockRandom;
    const string _specialCharacters = "!@#$%^&*()_-+=";

    [SetUp]
    public void Setup()
    {
        _mockRandom = new Mock<IRandom>();
        _cut = new PasswordGenerator(_mockRandom.Object);
    }

    [TestCase(1, 10)]
    [TestCase(6, 12)]
    [TestCase(12, 12)]
    public void GivenValidRange_Generate_ShallNotThrowException(
        int minLength, int maxLength)
    {
        Assert.DoesNotThrow(
            () => _cut.Generate(minLength, maxLength, It.IsAny<bool>()));
    }

    [Test]
    public void GivenValidRange_Generate_ShallReturnStringOfExpectedLength()
    {
        var minLength = 8;
        var maxLength = 12;
        var expectedLength = 10;
        SetupRandomToReturnExpectedLength(
            minLength, maxLength, expectedLength);

        var result = _cut.Generate(minLength, maxLength, It.IsAny<bool>());

        Assert.That(result, Is.TypeOf(typeof(string)));
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-50)]
    public void GivenMinLengthIsLessThanOne_ShallThrowException(int minLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(minLength, 10, It.IsAny<bool>()));
    }

    [TestCase(11)]
    [TestCase(50)]
    public void GivenMinLengthIsGreaterThanMaxLength_ShallThrowException(int minLength)
    {
        const int maxLength = 10;
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _cut.Generate(minLength, maxLength, It.IsAny<bool>()));
    }

    [Test]
    public void GivenIncludeSpecialTrue_Generate_ShouldIncludeSpecialCharacters()
    {
        var minLength = 4;
        var maxLength = 12;
        var expectedLength = 5;
        var includeSpecial = true;
        SetupRandomToReturnExpectedLength(
            minLength, maxLength, expectedLength);
        SetupRandomToReturnCharactersAtGivenIndices(0, 1, 42, 3, 46);

        var result = _cut.Generate(minLength, maxLength, includeSpecial);

        Assert.AreEqual("AB&D_", result);
    }

    [Test]
    public void GivenIncludeSpecialFalse_Generate_ShouldNotIncludeSpecialCharacters()
    {
        var minLength = 5;
        var maxLength = 5;
        var expectedLength = 5;
        var includeSpecial = false;
        SetupRandomToReturnExpectedLength(
            minLength, maxLength, expectedLength);
        SetupRandomToReturnCharactersAtGivenIndices(0, 1, 2, 3, 4);

        var result = _cut.Generate(minLength, maxLength, includeSpecial);

        Assert.AreEqual("ABCDE", result);
    }

    private void SetupRandomToReturnExpectedLength(
        int minLength, int maxLength, int expectedLength)
    {
        _mockRandom.Setup(mock => mock.Next(minLength, maxLength + 1))
            .Returns(expectedLength);
    }

    private void SetupRandomToReturnCharactersAtGivenIndices(params int[] indices)
    {
        var sequence = _mockRandom.SetupSequence(
            mock => mock.Next(It.IsAny<int>()));

        foreach (var index in indices)
        {
            sequence = sequence.Returns(index);
        }
    }
}