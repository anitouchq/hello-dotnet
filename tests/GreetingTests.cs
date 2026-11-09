using HelloDotnet;
using Xunit;

namespace HelloDotnet.Tests;

public class GreetingTests
{
    [Fact]
    public void Greet_ReturnsHelloForName()
    {
        Assert.Equal("Hello, .NET!", Greeting.Greet(".NET"));
    }

    [Fact]
    public void SumRange_ReturnsInclusiveSum()
    {
        Assert.Equal(55, Greeting.SumRange(1, 10));
    }

    [Fact]
    public void SumRange_ReturnsZeroWhenRangeIsReversed()
    {
        Assert.Equal(0, Greeting.SumRange(10, 1));
    }
}
