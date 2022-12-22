using Xunit;

namespace CloudCustomer.UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }

    [Theory]
    [InlineData("foo",1)]
    [InlineData("bar",1)]
    public void Test1(string input)
    {

    }
}