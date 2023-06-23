// using System;

namespace SquareEquationLib;

public class SquareEquation{
    public static double[] Solve(double a, double b, double c)
    {
        if(a == 0) throw new System.ArgumentException();
        if(Math.Abs(a) == double.PositiveInfinity || Math.Abs(b) == double.PositiveInfinity || Math.Abs(c) == double.PositiveInfinity) throw new System.ArgumentException();
        if(Double.IsNaN(a) || Double.IsNaN(b) || Double.IsNaN(c)) throw new System.ArgumentException();
        
        double eps = Math.Pow(10, -16);
        double D = b*b - 4*a*c;
       
        if(D > eps){
			double x1 = -(b + Math.Sign(b) * (Math.Sqrt(D)) / 2);
            double[] result = {x1, c / x1};
            return result;
        }
        else if(-eps < D && D <= eps){
            double[] result = {-b/(2*a)};
            return result;
        }
        else{
            double [] result = new double[0];
            return result;
        }
    }
}

// public class Program{
//     public static void Main(){
//         foreach(var i in SquareEquation.Solve(1, 2, -1)){
//             Console.WriteLine(i);
//         }
//     }
// }