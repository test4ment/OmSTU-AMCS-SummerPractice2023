using SquareEquationLib;
using Xunit;

namespace XUnit.Coverlet.Collector;

public class UnitTest1
{
    SquareEquation SquareEq = new SquareEquationLib.SquareEquation();
    //SquareEq.Solve(a, b, c)
    [Fact]
    public void TwoRoots()
    {
        double[] Answer = SquareEquation.Solve(1, -5, 4);
        double[] res1 = {4.0, 1.0};
        double[] res2 = {1.0, 4.0};
        double eps = Math.Pow(10, -9);
        Assert.True((Answer[0] - res1[0] < eps && Answer[1] - res1[1] < eps) || (Answer[0] - res2[0] < eps && Answer[1] - res2[1] < eps));
    }

    [Fact]
    public void OneRoot()
    {
        double[] Answer = SquareEquation.Solve(1, 2, 1);
        double[] res = {-1.0};
        double eps = Math.Pow(10, -9);
        Assert.True(Answer[0] - res[0] < eps);
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
        try{
            double[] Answer = SquareEquation.Solve(value1, value2, value3);
            Assert.True(false, "No error thrown");
        }
        catch (System.ArgumentException){
            Assert.True(true);
        }
    }
}