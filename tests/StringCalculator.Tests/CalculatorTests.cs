using StringCalculator.App;
using StringCalculator.App.Exceptions;
using Xunit;

public class CalculatorTests
{
    private readonly Calculator _calculator = new(new CalculatorOptions());

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        Assert.Equal(0, _calculator.Add("", out _));
    }

    [Fact]
    public void InvalidNumbers_AreConvertedToZero()
    {
        Assert.Equal(5, _calculator.Add("5,abc", out _));
    }

    [Fact]
    public void SupportsNewLineDelimiter()
    {
        Assert.Equal(6, _calculator.Add("1\n2,3", out _));
    }

    [Fact]
    public void ThrowsOnNegativeNumbers()
    {
        var ex = Assert.Throws<NegativeNumberException>(() =>
            _calculator.Add("1,-2,-3", out _));

        Assert.Contains("-2", ex.Message);
        Assert.Contains("-3", ex.Message);
    }

    [Fact]
    public void IgnoresNumbersGreaterThan1000()
    {
        Assert.Equal(8, _calculator.Add("2,1001,6", out _));
    }

    [Fact]
    public void SupportsSingleCustomDelimiter()
    {
        Assert.Equal(7, _calculator.Add("//#\n2#5", out _));
    }

    [Fact]
    public void SupportsCustomDelimiterOfAnyLength()
    {
        Assert.Equal(66, _calculator.Add("//[***]\n11***22***33", out _));
    }

    [Fact]
    public void SupportsMultipleCustomDelimiters()
    {
        Assert.Equal(110,
            _calculator.Add("//[*][!!][r9r]\n11r9r22*33!!44", out _));
    }
}
