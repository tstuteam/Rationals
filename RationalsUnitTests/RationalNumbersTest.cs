using Rationals;
using Xunit;

namespace RationalsUnitTests;

public sealed class RationalNumbersTest
{
    [Fact]
    public void Sum()
    {
        Assert.True((new Rational(1, 3) +
                     new Rational(2, 3)).AsDouble() == 3.3);
    }

    [Fact]
    public void TestMinus()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a - b).Equals(new Rational(1, 3)));
    }

    [Fact]
    public void TestMultiplication()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a * b).Equals(new Rational(6, 9)));
    }

    [Fact]
    public void TestDivide()
    {
        var a = new Rational(3, 3);
        var b = new Rational(2, 3);
        Assert.True((a / b).Equals(new Rational(3, 2)));
    }
}