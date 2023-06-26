using SquareEquationLib;
using Xunit;

namespace XUnit.Coverlet.MSBuild;

public class UnitTest1
{
    [Fact]
    public void TwoRoots()
    {
        double[] Answer = SquareEquation.Solve(1, -5, 4);
        Array.Sort(Answer);
        double[] expected = {1.0, 4.0};
        double eps = Math.Pow(10, -9);
        Assert.Equal(Answer[0], expected[0], eps);
        Assert.Equal(Answer[1], expected[1], eps);
    }

    [Fact]
    public void OneRoot()
    {
        double[] Answer = SquareEquation.Solve(1, 2, 1);
        double[] res = {-1.0};
        double eps = Math.Pow(10, -9);
        Assert.Equal(Answer[0], res[0], eps);
    }

    [Fact]
    public void NoRoots()
    {
        double[] Answer = SquareEquation.Solve(1, 1, 4);
        Assert.True(Answer.Length == 0);
    }

    [Theory]
    [InlineData(0, 4, 1)]
    [InlineData(1, double.NaN, -4)]
    [InlineData(1, 4, double.NegativeInfinity)]
    public void CauseErrors(double value1, double value2, double value3)
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(value1, value2, value3));
    }
}