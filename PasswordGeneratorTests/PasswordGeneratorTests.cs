using Moq;
using NUnit.Framework;

[TestFixture]
public class PasswordGeneratorTests
{
    PasswordGenerator _cut;
    Mock<IRandom> _rand;
    const string _specialCharacters = "!@#$%^&*()_-+=";

    [SetUp]
    public void Setup()
    {
        _rand = new Mock<IRandom>();
        _cut = new PasswordGenerator(_rand.Object);
    }

    [Test]
    public void GivenValidRange_Generate_ShallReturnStringOfProperLength()
    {
        var leftRange = 8;
        var rightRange = 12;
        var includeSpecial = true;
        _rand.Setup(m => m.Next(leftRange, rightRange))
            .Returns(10)
            .Verifiable();
        _rand.Setup(m => m.Next(50))
            .Returns(new Random().Next(50))
            .Verifiable();

        var result = _cut.Generate(leftRange, rightRange, includeSpecial);

        Assert.That(result, Is.TypeOf(typeof(string)));
        Assert.AreEqual(10, result.Length);
    }

    [Test]
    public void GivenLeftRangeIsLessThanOne_ShallThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _cut.Generate(0, 10, false));
    }

    [Test]
    public void GivenLeftRangeIsGreaterThanRightRange_ShallThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _cut.Generate(10, 5, false));
    }

    [Ignore("not testable")]
    public void GivenSpecialCharTrue_Generate_ShouldIncludeSpecialCharacters()
    {
        var leftRange = 8;
        var rightRange = 12;
        var includeSpecial = true;
        _rand.Setup(m => m.Next(leftRange, rightRange))
            .Returns(10)
            .Verifiable();
        _rand.Setup(m => m.Next(It.IsAny<int>()))
            .Returns(new Random().Next(50))
            .Verifiable();

        var result = _cut.Generate(leftRange, 12, includeSpecial);

        var intersection = result.Intersect(_specialCharacters);
        Assert.IsNotEmpty(intersection);
    }

    [Ignore("not testable")]
    public void GivenSpecialCharFalse_Generate_ShouldNotIncludeSpecialCharacters()
    {
        var result = _cut.Generate(5, 10, false);
        var intersection = result.Intersect(_specialCharacters);
        Assert.IsEmpty(intersection);
    }

}