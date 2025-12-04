using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    public void Limiter_ShouldClampValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("  abcdefghijklmnop  ", 3, 5, '#', "Abcde")]
    [InlineData("a", 3, 5, '#', "A##")]
    [InlineData(null, 3, 5, '#', "###")]
    [InlineData("   cats  ", 3, 10, '#', "Cats")]
    [InlineData("mICE", 3, 10, '#', "MICE")]
    public void Shortener_ShouldTrimPadAndCapitalize(string? input, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(input, min, max, placeholder);

        Assert.Equal(expected, result);
    }
}
